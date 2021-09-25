namespace GildedRoseKata.Inventory.Utilities
{
    public static partial class ItemUtils
    {
        public static partial class Quality
        {
            public static Item Constrain(Item item) => 
                item.Clone(new ItemProps
                {
                    Quality = GetConstraint(item.Quality)
                });

            private static int GetConstraint(int quality) => quality switch
            {
                > (int) Rules.Quality.Constraints.Upper => (int) Rules.Quality.Constraints.Upper,
                < (int) Rules.Quality.Constraints.Lower => (int) Rules.Quality.Constraints.Lower,
                _ => quality
            };
        }
    }
}