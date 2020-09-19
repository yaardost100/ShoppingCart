using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Entities
{
    public class Promotion
    {
        public string PromotionType { get; set; }
        public List<Distribution> Combination { get; set; }
        public int Price { get; set; }
    }
}
