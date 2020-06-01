using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleECommerce.Api.Models;
using SampleECommerce.Core.DTO;
using SampleECommerce.Core.Enums;
using SampleECommerce.Service.ShoppingCart;

namespace SampleECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        [Route("getShoppingCart")]
        public ActionResult<ApiResultDto<ShoppingCartDto>> GetShoppingCart(int customerId)
        {
            var result = new ApiResultDto<ShoppingCartDto>();
            var shoppingCart = _shoppingCartService.GetShoppingCart(customerId);
            result.Data = shoppingCart;
            return result;
        }
        
        [HttpPost]
        [Route("addToCart")]
        public ActionResult<ApiResultDto<bool>> AddToCart([FromBody] AddToCartViewModel model)
        {
            var isAdded = _shoppingCartService.AddToCart(model.CustomerId, model.ProductId, model.Quantity);
            var result = new ApiResultDto<bool>
            {
                Data = isAdded,
                Status = isAdded ? ResultStatusEnum.Success : ResultStatusEnum.Error,
                Message = isAdded ? "Item has been added to cart successfully." : "Has no stock."
            };
            return result;
        }
    }
}