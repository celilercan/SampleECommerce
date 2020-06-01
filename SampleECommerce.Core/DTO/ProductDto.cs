using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Core.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
