using Moq;
using SampleECommerce.Core.Caching;
using SampleECommerce.Core.DTO;
using SampleECommerce.Service.ShoppingCart;
using Xunit;

namespace SampleECommerce.Test.ShoppingCart
{
    public class ShoppingCartTest
    {
        private readonly ICacheManager _cacheManager;
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartTest(ICacheManager cacheManager, IShoppingCartService shoppingCartService)
        {
            _cacheManager = cacheManager;
            _shoppingCartService = shoppingCartService;
        }

        [Fact]
        public void AddToCart_ShouldFalse_WhenHasNoStock_Test()
        {
            //Arrange
            var fakeCustomerId = 5;

            var addToCartResult = _shoppingCartService.AddToCart(fakeCustomerId, 2, 5);

            Assert.False(addToCartResult);
        }

        [Fact]
        public void AddToCart_ShouldTrue_Test()
        {
            //Arrange
            var fakeCustomerId = 5;

            var addToCartResult = _shoppingCartService.AddToCart(fakeCustomerId, 2, 1);

            Assert.True(addToCartResult);
        }
    }
}
