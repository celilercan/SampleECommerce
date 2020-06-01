using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleECommerce.Api.Models
{
    public class AddToCartViewModel
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
