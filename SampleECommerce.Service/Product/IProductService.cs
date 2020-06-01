using SampleECommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Service.Product
{
    public interface IProductService
    {
        bool CheckStock(int productId, int quantity);

        ProductDto GetProductById(int id);
    }
}
