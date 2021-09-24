using System.Linq;

namespace GildedRoseKata
{
    public static class ItemUtils
    {
        public static class Quality
        {
            public static void Adjust(Item item, int amount) =>
                item.Quality += amount * GetAdjustmentFactor(item);
            
            public static void Adjust(Item item) =>
                Adjust(item, -1);
            
            private static int GetAdjustmentFactor(Item item) =>
                Rules.Quality.AdjustmentFactors
                    .Where(f => f(item))
                    .Aggregate(1, (current, _) => current * 2);

            public static void Constrain(Item item) =>
                item.Quality = GetConstraint(item.Quality);

            private static int GetConstraint(int quality) => quality switch
            {
                > (int) Rules.Quality.Constraints.Upper => (int) Rules.Quality.Constraints.Upper,
                < (int) Rules.Quality.Constraints.Lower => (int) Rules.Quality.Constraints.Lower,
                _ => quality
            };
        }

        public static class SellIn
        {
            public static void Decrement(Item item) =>
                item.SellIn--;
        }
    }
}