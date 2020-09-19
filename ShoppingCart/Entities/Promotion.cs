using System.Collections.Generic;

namespace ShoppingCart.Entities
{
    public class Promotion
    {
        public string PromotionType { get; set; }
        public List<Distribution> Combination { get; set; }
        public int Price { get; set; }
    }
}