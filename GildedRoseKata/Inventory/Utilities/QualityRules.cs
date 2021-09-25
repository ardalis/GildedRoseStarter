using System;
using System.Collections.Generic;
using GildedRoseKata.Inventory.Utilities.Special;

namespace GildedRoseKata.Inventory.Utilities
{
    public static partial class Rules
    {
        public static class Quality
        {
            public static readonly List<Predicate<Item>> AdjustmentFactors = new()
            {
                item => item.SellIn <= 0,
                Conjured.AdjustmentFactor
            };

            public static readonly Dictionary<string, Func<Item, Item>> AdjustmentRules = new()
                {
                    {Sulfuras.Name, Sulfuras.TheOneRuleOfRagnaros},
                    {BackstagePasses.Name, BackstagePasses.Adjust},
                    {AgedBrie.Name, AgedBrie.Adjust}
                }
            ;
            
            public static readonly Dictionary<string, Func<Item,Item>> ConstraintRules = new()
            {
                {Sulfuras.Name, Sulfuras.TheOneRuleOfRagnaros}
            };

            public enum Constraints
            {
                Lower = 0,
                Upper = 50
            }
        }
    }
}