using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class BackstagePassesUtils
    {
        private const string Name = "Backstage passes to a TAFKAL80ETC concert";

        public static KeyValuePair<string, Action<Item>> QualityException = 
            new(Name, Adjust);
        
        private static void Adjust(Item item)
        {
            if (item.SellIn == 0) item.Quality = 0;
            else ItemUtils.Quality.Adjust(item, GetAdjustmentAmount(item.SellIn));
        }

        private static int GetAdjustmentAmount(int sellIn) => sellIn switch
        {
            <= 0 => 0,
            <= 5 => 3,
            <= 10 => 2,
            _ => 1
        };
    }
}