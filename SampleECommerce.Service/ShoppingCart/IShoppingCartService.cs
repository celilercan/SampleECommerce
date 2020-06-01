using SampleECommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Service.ShoppingCart
{
    public interface IShoppingCartService
    {
        bool AddToCart(int customerId, int productId, int quantity);

        ShoppingCartDto GetShoppingCart(int customerId);
    }
}
