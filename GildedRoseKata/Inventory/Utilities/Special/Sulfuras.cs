namespace GildedRoseKata.Inventory.Utilities.Special
{
    public static class Sulfuras
    {
        public static string Name => "Sulfuras, Hand of Ragnaros";

        public static Item TheOneRuleOfRagnaros(Item item) => item.Clone();
    }
}