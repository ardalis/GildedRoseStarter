using System.Collections.Generic;
using System.Linq;
using GildedRoseKata.Inventory;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public IEnumerable<Item> Inventory => Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            Items = Items.Select(item => item.Update()).ToList();
        }
    }
}