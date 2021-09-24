using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class Rules
    {
        public static class Quality
        {
            public static readonly List<Predicate<Item>> AdjustmentFactors = new()
            {
                item => item.SellIn == 0,
                ConjuredUtils.AdjustmentFactor
            };

            public static readonly Dictionary<string, Action<Item>> Exceptions = new(new[]
                {
                    SulfurasUtils.TheOneRuleOfRagnaros,
                    BackstagePassesUtils.QualityException,
                    AgedBrieUtils.QualityException
                }
            );

            public static readonly Dictionary<string, Action<Item>> ConstraintExceptions = new(new[]
                {SulfurasUtils.TheOneRuleOfRagnaros}
            );

            public enum Constraints
            {
                Lower = 0,
                Upper = 50
            }
        }

        public static class SellIn
        {
            public static readonly Dictionary<string, Action<Item>> Exceptions = new(new[]
                {SulfurasUtils.TheOneRuleOfRagnaros}
            );
        }
    }
}