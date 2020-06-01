using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleECommerce.Core.DTO;

namespace SampleECommerce.Service.Product
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Default Products
        /// </summary>
        private List<ProductDto> _productList
        {
            get
            {
                return new List<ProductDto>
                {
                    new ProductDto { Id = 1, ProductName = "Ürün 1", Price = 29.99m, Stock = 55 },
                    new ProductDto { Id = 2, ProductName = "Ürün 2", Price = 59.99m, Stock = 2 },
                    new ProductDto { Id = 3, ProductName = "Ürün 3", Price = 49.99m, Stock = 30 }
                };
            }
        }

        public bool CheckStock(int productId, int quantity)
        {
            var product = _productList.FirstOrDefault(x => x.Id == productId);
            if (product == null)
                return false;

            return product.Stock >= quantity;
        }

        public ProductDto GetProductById(int id)
        {
            return _productList.FirstOrDefault(x => x.Id == id);
        }
    }
}
