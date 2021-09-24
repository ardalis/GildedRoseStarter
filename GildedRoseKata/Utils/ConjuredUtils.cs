using System;

namespace GildedRoseKata
{
    public static class ConjuredUtils
    {
        private const string Name = "Conjured";
        
        public static readonly Predicate<Item> AdjustmentFactor = 
            item => item.Name.StartsWith(Name);
    }
}