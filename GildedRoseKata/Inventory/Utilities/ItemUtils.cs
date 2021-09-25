using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata.Inventory.Utilities
{
    public static partial class ItemUtils
    {
        public static Item GetRuleOrDefault(
            Item item,
            Dictionary<string, Func<Item, Item>> rules,
            Func<Item, Item> defaultRule
        ) => GetRule(item, rules) is string rule
            ? rules[rule](item)
            : defaultRule(item);

        private static string GetRule(Item item, Dictionary<string, Func<Item, Item>> rules) =>
            rules.Keys.FirstOrDefault(item.Name.Contains);
    }
}