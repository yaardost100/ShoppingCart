using Newtonsoft.Json;
using ShoppingCart.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShoppingCart.Tests
{
    public partial class ShoppingCartTests
    {
        private async Task<IEnumerable<Promotion>> SetUpPromotions()
        {
            var promotionsJson = await File.ReadAllTextAsync("Promotions.json");
            var promos = JsonConvert.DeserializeObject<List<Promotion>>(promotionsJson);

            return promos;
        }

        private async Task<IEnumerable<SKUPrice>> SetUpSKUDefaultPrices()
        {
            var skuUnitPriceJson = await File.ReadAllTextAsync("SKUUnitPrice.json");
            var skuUnitPrice = JsonConvert.DeserializeObject<List<SKUPrice>>(skuUnitPriceJson);

            return skuUnitPrice;
        }
    }
}