#nullable enable

namespace GildedRoseKata.Inventory
{
    public static partial class ItemExtensions
    {
        public static Item Clone(this Item item, ItemProps? props) =>
            new()
            {
                Name = item.Name,
                Quality = props?.Quality ?? item.Quality,
                SellIn = props?.SellIn ?? item.SellIn
            };
        
        public static Item Clone(this Item item) =>
            item.Clone(null);
    }
}