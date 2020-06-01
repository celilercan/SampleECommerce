using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleECommerce.Core.DTO
{
    public class ShoppingCartDto
    {
        public ShoppingCartDto()
        {
            ShoppingCartItems = new List<ShoppingCartItemDto>();
        }

        public int CustomerId { get; set; }

        public List<ShoppingCartItemDto> ShoppingCartItems { get; set; }

        public decimal AbsoluteTotal
        {
            get
            {
                return this.ShoppingCartItems.Sum(x => x.TotalPrice);
            }
        }
    }
}
