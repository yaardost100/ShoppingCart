using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        private readonly IEnumerable<SKUPrice> _skuPrice;
        private readonly IEnumerable<Promotion> _promotions;
        public Dictionary<string, int> CurrentCart { get; set; }

        public ShoppingCart(IEnumerable<SKUPrice> skuPrice, IEnumerable<Promotion> promotions)
        {
            _skuPrice = skuPrice;
            _promotions = promotions;
        }

        public int ApplyPromotions()
        {
            if (!_promotions.Any())
            {
                return CalculatePriceWithoutPromotion();
            }
            throw new NotImplementedException();
        }

        private int CalculatePriceWithoutPromotion()
        {
            var cartPrice = 0;
            var skuDefaults = _skuPrice.ToDictionary(item => item.SKUId, item => item.Price);
            foreach (var keyValuePair in CurrentCart)
            {
                cartPrice += skuDefaults[keyValuePair.Key] * keyValuePair.Value;
            }

            return cartPrice;
        }
    }
}