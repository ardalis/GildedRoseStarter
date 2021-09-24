using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class SulfurasUtils
    {
        private const string Name = "Sulfuras, Hand of Ragnaros";
        
        public static KeyValuePair<string, Action<Item>> TheOneRuleOfRagnaros = 
            new(Name, _ => { });
    }
}