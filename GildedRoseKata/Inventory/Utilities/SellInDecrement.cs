namespace GildedRoseKata.Inventory.Utilities
{
    public static partial class ItemUtils
    {
        public static class SellIn
        {
            public static Item Decrement(Item item) =>
                item.Clone(new ItemProps
                {
                    SellIn = item.SellIn - 1
                });
        }
    }
}