namespace GildedRoseKata.Inventory.Utilities.Special
{
    public static class AgedBrie
    {
        public static string Name => "Aged Brie";
        
        public static Item Adjust(Item item) => 
            ItemUtils.Quality.Adjust(item, 1);
    }
}