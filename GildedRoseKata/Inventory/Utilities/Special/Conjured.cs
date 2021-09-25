using System;

namespace GildedRoseKata.Inventory.Utilities.Special
{
    public static class Conjured
    {
        private static string Name => "Conjured";
        
        public static readonly Predicate<Item> AdjustmentFactor = 
            item => item.Name.StartsWith(Name);
    }
}