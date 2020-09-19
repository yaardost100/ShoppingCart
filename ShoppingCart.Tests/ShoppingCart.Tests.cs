using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public partial class ShoppingCartTests
    {
        public async Task ApplyPromotion_ScenarioAValidPromos_ReturnsCorrectPrice()
        {
            var promotions = await SetUpPromotions();
            var skuDefaults = await SetUpSKUDefaultPrices();
            var shoppingCart = new ShoppingCart(skuDefaults, promotions)
            {
                CurrentCart = new Dictionary<string, int> { { "A", 1 }, { "B", 1 }, { "C", 1 } }
            };

            var expectedPrice = 100;
            var actualPrice = shoppingCart.ApplyPromotions();

            Assert.Equal(expectedPrice, actualPrice);
        }
        public async Task ApplyPromotion_ScenarioBValidPromos_ReturnsCorrectPrice()
        {
            var promotions = await SetUpPromotions();
            var skuDefaults = await SetUpSKUDefaultPrices();
            var shoppingCart = new ShoppingCart(skuDefaults, promotions)
            {
                CurrentCart = new Dictionary<string, int> { { "A", 5 }, { "B", 5 }, { "C", 1 } }
            };

            var expectedPrice = 370;
            var actualPrice = shoppingCart.ApplyPromotions();

            Assert.Equal(expectedPrice, actualPrice);
        }
        public async Task ApplyPromotion_ScenarioCValidPromos_ReturnsCorrectPrice()
        {
            var promotions = await SetUpPromotions();
            var skuDefaults = await SetUpSKUDefaultPrices();
            var shoppingCart = new ShoppingCart(skuDefaults, promotions)
            {
                CurrentCart = new Dictionary<string, int> { { "A", 3 }, { "B", 5 }, { "C", 1 }, { "D", 1 } }
            };

            var expectedPrice = 280;
            var actualPrice = shoppingCart.ApplyPromotions();

            Assert.Equal(expectedPrice, actualPrice);
        }
        public async Task ApplyPromotion_ScenarioAValidNoPromos_ReturnsCorrectPrice()
        {
            var promotions = await SetUpPromotions();
            var skuDefaults = await SetUpSKUDefaultPrices();
            var shoppingCart = new ShoppingCart(skuDefaults, promotions)
            {
                CurrentCart = new Dictionary<string, int> { { "A", 1 }, { "B", 1 }, { "C", 1 } }
            };

            var expectedPrice = 100;
            var actualPrice = shoppingCart.ApplyPromotions();

            Assert.Equal(expectedPrice, actualPrice);
        }
        public async Task ApplyPromotion_ScenarioBValidNoPromos_ReturnsCorrectPrice()
        {
            var promotions = await SetUpPromotions();
            var skuDefaults = await SetUpSKUDefaultPrices();
            var shoppingCart = new ShoppingCart(skuDefaults, promotions)
            {
                CurrentCart = new Dictionary<string, int> { { "A", 1 }, { "B", 1 }, { "C", 1 } }
            };

            var expectedPrice = 420;
            var actualPrice = shoppingCart.ApplyPromotions();

            Assert.Equal(expectedPrice, actualPrice);
        }
        public async Task ApplyPromotion_ScenarioCValidNoPromos_ReturnsCorrectPrice()
        {
            var promotions = await SetUpPromotions();
            var skuDefaults = await SetUpSKUDefaultPrices();
            var shoppingCart = new ShoppingCart(skuDefaults, promotions)
            {
                CurrentCart = new Dictionary<string, int> { { "A", 1 }, { "B", 1 }, { "C", 1 } }
            };

            var expectedPrice = 335;
            var actualPrice = shoppingCart.ApplyPromotions();

            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}