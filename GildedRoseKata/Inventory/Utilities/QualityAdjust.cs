using System.Linq;

namespace GildedRoseKata.Inventory.Utilities
{
    public static partial class ItemUtils
    {
        public static partial class Quality
        {
            public static Item Adjust(Item item, int amount) =>
                item.Clone(new ItemProps
                {
                    Quality = item.Quality + amount * GetAdjustmentFactor(item)
                });

            public static Item Adjust(Item item) =>
                Adjust(item, -1);

            private static int GetAdjustmentFactor(Item item) =>
                Rules.Quality.AdjustmentFactors
                    .Where(f => f(item))
                    .Aggregate(1, (current, _) => current * 2);
        }
    }
}