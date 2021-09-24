using FluentAssertions;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRoseKata
{
    /// <summary>
    /// Test naming convention recommendation:
    /// https://ardalis.com/unit-test-naming-convention/
    /// </summary>
    public class GildedRose_UpdateQuality
    {
        [Fact]
        public void DoesNothingGivenSulfuras()
        {
            const int initialQuality = 80;
            var items = new List<Item> {
                                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = initialQuality},

            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();
            
            // Use your preferred assertion library (already included - pick one delete others)
            // xunit default
            Assert.Equal(initialQuality, firstItem.Quality);

            // fluentassertions
            firstItem.Quality.Should().Be(initialQuality);

            // shouldly
            firstItem.Quality.ShouldBe(initialQuality);
        }
        
        [Fact]
        public void DegradesTwiceAsFastAfterSellby()
        {
            const int initialQuality = 2;
            var items = new List<Item> {
                new() {Name = "expired", SellIn = 0, Quality = initialQuality},

            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();

            const int expectedQuality = 0;

            // fluentassertions
            firstItem.Quality.Should().Be(expectedQuality);
        }
        
        [Fact]
        public void QualityNeverNegative()
        {
            int initialQuality = 1;
            var items = new List<Item> {
                new() {Name = "never neg", SellIn = 0, Quality = initialQuality},

            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();

            var expectedQuality = 0;

            // fluentassertions
            firstItem.Quality.Should().Be(expectedQuality);
        }
        
        [Fact]
        public void DegradesOncePerUpdate()
        {
            int initialQuality = 2;
            var items = new List<Item> {
                new() {Name = "normal", SellIn = 99, Quality = initialQuality},

            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();

            var expectedQuality = 1;

            // fluentassertions
            firstItem.Quality.Should().Be(expectedQuality);
        }
        
        [Fact]
        public void AgedBrieIncreasesInQuality()
        {
            int initialQuality = 2;
            var items = new List<Item> {
                new() {Name = "Aged Brie", SellIn = 99, Quality = initialQuality},

            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();

            var expectedQuality = 3;

            // fluentassertions
            firstItem.Quality.Should().Be(expectedQuality);
        }
        
        [Fact]
        public void BackStagePassesIncreaseInQuality()
        {
            const int initialQuality = 25;
            var items = new List<Item> {
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = initialQuality},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = initialQuality},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = initialQuality},
                new() {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = initialQuality},
            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();
            
            items[0].Quality.Should().Be(26);
            items[1].Quality.Should().Be(27);
            items[2].Quality.Should().Be(28);
            items[3].Quality.Should().Be(0);
        }
        
        [Fact]
        public void ConjuredDegradeTwiceAsFast()
        {
            int initialQuality = 5;
            var items = new List<Item> {
                new() {Name = "Conjured", SellIn = 99, Quality = initialQuality},

            };
            var gildedRose = new GildedRose(items);
            
            gildedRose.UpdateQuality();

            var firstItem = items.First();

            var expectedQuality = 3;

            // fluentassertions
            firstItem.Quality.Should().Be(expectedQuality);
        }
    }
}
