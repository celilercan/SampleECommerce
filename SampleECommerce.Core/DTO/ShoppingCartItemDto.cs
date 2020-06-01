using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Core.DTO
{
    public class ShoppingCartItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return this.ProductPrice * this.Quantity;
            }
        }
    }
}
