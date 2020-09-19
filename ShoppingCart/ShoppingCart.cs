using ShoppingCart.Entities;
using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        private readonly IEnumerable<SKUPrice> _skuPrice;
        private readonly IEnumerable<Promotion> _promotions;
        public Dictionary<string, int> CurrentCart { get; set; }

        public ShoppingCart(List<SKUPrice> skuPrice, List<Promotion> promotions)
        {
            _skuPrice = skuPrice;
            _promotions = promotions;
        }

        public int ApplyPromotions()
        {
            throw new NotImplementedException();
        }
    }
}