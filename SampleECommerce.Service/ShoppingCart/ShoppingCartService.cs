using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleECommerce.Core.Caching;
using SampleECommerce.Core.Caching.Constants;
using SampleECommerce.Core.DTO;
using SampleECommerce.Core.Extensions;
using SampleECommerce.Service.Product;

namespace SampleECommerce.Service.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ICacheManager _cacheManager;
        private readonly IProductService _productService;

        public ShoppingCartService(ICacheManager cacheManager, IProductService productService)
        {
            _cacheManager = cacheManager;
            _productService = productService;
        }

        public bool AddToCart(int customerId, int productId, int quantity)
        {
            if (!_productService.CheckStock(productId, quantity))
            {
                return false; ////has no stock
            }

            var shoppingCart = this.GetShoppingCart(customerId);

            if (shoppingCart.ShoppingCartItems.Any(x => x.ProductId == productId))
            {
                var item = shoppingCart.ShoppingCartItems.First(x => x.ProductId == productId);
                item.Quantity += quantity;
            }
            else
            {
                var product = _productService.GetProductById(productId);
                shoppingCart.ShoppingCartItems.Add(new ShoppingCartItemDto
                {
                    ProductId = productId,
                    ProductName = product.ProductName,
                    ProductPrice = product.Price,
                    Quantity = quantity
                });
            }

            _cacheManager.Set(string.Format(CommonConstants.ShoppingCartCustomerByIdKey, customerId), shoppingCart, 60);

            return true;
        }

        public ShoppingCartDto GetShoppingCart(int customerId)
        {
            return _cacheManager.Get(
                string.Format(CommonConstants.ShoppingCartCustomerByIdKey, customerId), 
                () => 
                {
                    return new ShoppingCartDto
                    {
                        CustomerId = customerId
                    };
                });
        }
    }
}
