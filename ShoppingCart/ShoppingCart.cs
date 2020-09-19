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
                return CalculatePriceWithoutPromotion(CurrentCart);
            }

            return CalculatePriceWithPromotions();
        }

        private int CalculatePriceWithoutPromotion(Dictionary<string, int> cart)
        {
            var cartPrice = 0;
            var skuDefaults = _skuPrice.ToDictionary(item => item.SKUId, item => item.Price);
            foreach (var keyValuePair in cart)
            {
                cartPrice += skuDefaults[keyValuePair.Key] * keyValuePair.Value;
            }

            return cartPrice;
        }

        private int CalculatePriceWithPromotions()
        {
            var cartPrice = 0;
            var skuDefaults = _skuPrice.ToDictionary(item => item.SKUId, item => item.Price);
            var cartClone = CurrentCart.ToDictionary(item => item.Key, item => item.Value);

            foreach (var promo in _promotions)
            {
                var combination = promo.Combination;
                //If every item in the promo is present in the cart and all their Quantity is >= in the Promo
                //then only apply otherwise that promotion is not applicable
                if (combination.All(combination => cartClone.ContainsKey(combination.SKUId) &&
                     cartClone[combination.SKUId] >= combination.Weigth))
                {
                    var price = 0;
                    foreach (var comb in combination)
                    {
                        var promoCount = comb.Weigth;
                        var cartCount = cartClone[comb.SKUId];

                        price = (cartCount / promoCount) * promo.Price;
                        cartClone[comb.SKUId] = cartCount % promoCount;
                    }
                    cartPrice += price;
                }
            }

            //After Promo then whatever is left use it to apply individual logic
            cartPrice += CalculatePriceWithoutPromotion(cartClone);

            return cartPrice;
        }
    }
}