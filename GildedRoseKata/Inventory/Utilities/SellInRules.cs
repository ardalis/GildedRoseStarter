using System;
using System.Collections.Generic;
using GildedRoseKata.Inventory.Utilities.Special;

namespace GildedRoseKata.Inventory.Utilities
{
    public static partial class Rules
    {
        public static class SellIn
        {
            public static readonly Dictionary<string, Func<Item, Item>> DecrementRules = new()
            {
                {Sulfuras.Name, Sulfuras.TheOneRuleOfRagnaros}
            };
        }   
    }
}