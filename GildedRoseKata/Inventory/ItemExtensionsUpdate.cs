#nullable enable
using GildedRoseKata.Inventory.Utilities;

namespace GildedRoseKata.Inventory
{
    public static partial class ItemExtensions
    {
        public static Item Update(this Item item) =>
            item.AdjustQuality()
                .ConstrainQuality()
                .DecrementSellIn();

        private static Item AdjustQuality(this Item item) =>
            ItemUtils.GetRuleOrDefault(item, Rules.Quality.AdjustmentRules, ItemUtils.Quality.Adjust);

        private static Item ConstrainQuality(this Item item) =>
            ItemUtils.GetRuleOrDefault(item, Rules.Quality.ConstraintRules, ItemUtils.Quality.Constrain);

        private static Item DecrementSellIn(this Item item) =>
            ItemUtils.GetRuleOrDefault(item, Rules.SellIn.DecrementRules, ItemUtils.SellIn.Decrement);
    }
}