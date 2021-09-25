using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseKata.Inventory;
using NUnit.Framework;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GildedRoseTests
    {
        [TestCaseSource(typeof(GildedRoseTestItems), nameof(GildedRoseTestItems.TestCases))]
        public void UpdateItemQuality(Item item, int loops, int expectedQuality, int? expectedSellIn)
        {
            var initialSellIn = item.SellIn;
            
            var gildedRose = new GildedRose(new List<Item> {item});
            for (var i = 0; i < loops; i++)
            {
                gildedRose.UpdateQuality();
            }

            var updatedItem = gildedRose.Inventory.First();

            updatedItem.Should().NotBeNull();
            updatedItem.Quality.Should().Be(expectedQuality);

            if (expectedSellIn.HasValue)
            {
                updatedItem.SellIn.Should().Be(expectedSellIn);
            }
            else updatedItem.SellIn.Should().Be(initialSellIn - loops);
        }

        private class GildedRoseTestItems
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new Item
                        {
                            Name = "Sulfuras, Hand of Ragnaros",
                            SellIn = 0,
                            Quality = 80
                        },
                        1,
                        80,
                        0
                    ).SetName("DoesNothingGivenSulfuras");

                    yield return new TestCaseData(
                        new Item
                        {
                            Name = "expired", SellIn = 0, Quality = 10
                        },
                        3,
                        4,
                        null
                    ).SetName("DegradesTwiceAsFastAfterSellby");
                    
                    yield return new TestCaseData(
                        new Item
                        {
                            Name = "lower constraint", SellIn = 0, Quality = 5
                        },
                        10,
                        0,
                        null
                    ).SetName("Quality Can't Be Negative");
                    
                    yield return new TestCaseData(
                        new Item
                        {
                            Name = "upper constraint", SellIn = 10, Quality = 99
                        },
                        1,
                        50,
                        null
                    ).SetName("Quality Can't Be Above 50")
                        .SetCategory("Aged Brie");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Aged Brie", SellIn = 10, Quality = 25
                            },
                            10,
                            35,
                            null
                        ).SetName("Quality Can't Be Above 50")
                        .SetCategory("Aged Brie Inceases In Quality");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Aged Brie", SellIn = 0, Quality = 25
                            },
                            10,
                            45,
                            null
                        ).SetName("Quality Can't Be Above 50")
                        .SetCategory("Aged Brie Inceases In Quality Doubly After SellIn 0");
                    
                    yield return new TestCaseData(
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert", 
                            SellIn = 15, 
                            Quality = 25
                        },
                        5,
                        30,
                        null
                    ).SetName("Backstage Passes Increase In Quality")
                        .SetCategory("Backstage Passes");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert", 
                                SellIn = 10, 
                                Quality = 25
                            },
                            5,
                            35,
                            null
                        ).SetName("Backstage Passes Increase In Quality By 2 When SellIn < 10")
                        .SetCategory("Backstage Passes");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert", 
                                SellIn = 5, 
                                Quality = 25
                            },
                            5,
                            40,
                            null
                        ).SetName("Backstage Passes Increase In Quality By 3 When SellIn < 5")
                        .SetCategory("Backstage Passes");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert", 
                                SellIn = 0, 
                                Quality = 25
                            },
                            1,
                            0,
                            null
                        ).SetName("Backstage Passes Quality Drops to 0 When SellIn 0")
                        .SetCategory("Backstage Passes");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Backstage passes to a TAFKAL80ETC concert", 
                                SellIn = -1, 
                                Quality = 25
                            },
                            1,
                            0,
                            null
                        ).SetName("Backstage Passes Quality Drops to 0 When SellIn < 0")
                        .SetCategory("Backstage Passes");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Conjured item", 
                                SellIn = 1, 
                                Quality = 25
                            },
                            3,
                            15,
                            null
                        ).SetName("Conjured Items Change Quality Twice As Fast")
                        .SetCategory("Conjured Items");
                    
                    yield return new TestCaseData(
                            new Item
                            {
                                Name = "Conjured Aged Brie", 
                                SellIn = 1, 
                                Quality = 25
                            },
                            3,
                            35,
                            null
                        ).SetName("Conjured Brie Increases Quality Twice As Fast")
                        .SetCategory("Conjured Items");
                }
            }
        }
    }
}