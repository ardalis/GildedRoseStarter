using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public static class ItemExtensions
    {
        public static Item AdjustQuality(this Item item) =>
            GetExceptionOrDefault(item, Rules.Quality.Exceptions, ItemUtils.Quality.Adjust);

        public static Item ConstrainQuality(this Item item) =>
            GetExceptionOrDefault(item, Rules.Quality.ConstraintExceptions, ItemUtils.Quality.Constrain);

        public static void DecrementSellIn(this Item item) =>
            GetExceptionOrDefault(item, Rules.SellIn.Exceptions, ItemUtils.SellIn.Decrement);

        private static Item GetExceptionOrDefault(
            Item item,
            Dictionary<string, Action<Item>> exceptions,
            Action<Item> defaultAction
        )
        {
            if (exceptions.Keys.FirstOrDefault(item.Name.Contains) is string exception)
                exceptions[exception](item);
            else defaultAction(item);
            return item;
        }
    }
}