using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class AgedBrieUtils
    {
        private const string Name = "Aged Brie";
        
        public static KeyValuePair<string, Action<Item>> QualityException = 
            new(Name, item => ItemUtils.Quality.Adjust(item, 1));
    }
}