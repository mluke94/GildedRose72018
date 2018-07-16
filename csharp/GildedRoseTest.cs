using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdatingQualityDoesNotChangeItemName()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void UpdatingQualityLowersQualityByOneIfNotExpiredForGenericItems()
        {
            var startingQuality = 100;
            var expectedQuality = 99;
            IList<Item> Items = new List<Item> { new Item { Name = "generic", SellIn = 1, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityLowersQualityByTwoIfExpiredForGenericItems()
        {
            var startingQuality = 100;
            var expectedQuality = 98;
            IList<Item> Items = new List<Item> { new Item { Name = "generic", SellIn = 0, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityDoesNotLowerQualityLessThanZeroForGenericItems()
        {
            var startingQuality = 0;
            IList<Item> Items = new List<Item> { new Item { Name = "generic", SellIn = 0, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(startingQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityIncreasesQualityByOneBeforeExpirationForAgedBrie()
        {
            var startingQuality = 30;
            var expectedQuality = 31;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.AgedBrieName, SellIn = 5, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityIncreasesQualityByOneBeforeExpirationForBackstagePasses()
        {
            var startingQuality = 30;
            var expectedQuality = 31;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.BackstagePassName, SellIn = 15, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityIncreasesQualityByTwoWithSellInAtTenOrLessForBackstagePasses()
        {
            var startingQuality = 30;
            var expectedQuality = 32;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.BackstagePassName, SellIn = 10, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityIncreasesQualityByThreeWithSellInAtFiveOrLessForBackstagePasses()
        {
            var startingQuality = 30;
            var expectedQuality = 33;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.BackstagePassName, SellIn = 5, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualitySetsQualityToZeroWhenExpiredForBackstagePasses()
        {
            var startingQuality = 30;
            var expectedQuality = 0;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.BackstagePassName, SellIn = 0, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityDoesNotIncreaseQualityGreaterThan50ForAgedBrie()
        {
            var startingQuality = 50;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.AgedBrieName, SellIn = 5, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(startingQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityIncreasesQualityByTwoAfterExpirationForAgedBrie()
        {
            var startingQuality = 30;
            var expectedQuality = 32;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.AgedBrieName, SellIn = 0, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }

        [Test]
        public void UpdatingQualityLowersSellInByOneForGenericItems()
        {
            var startingSellIn = 100;
            var expectedSellIn = 99;
            IList<Item> Items = new List<Item> { new Item { Name = "generic", SellIn = startingSellIn, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedSellIn, Items[0].SellIn);
        }

        [Test]
        public void UpdatingQualityForSulfurasDoesNotChangeSellIn()
        {
            var startingSellIn = 100;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.SulfurasName, SellIn = startingSellIn, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(startingSellIn, Items[0].SellIn);
        }

        [Test]
        public void UpdatingQualityForSulfurasDoesNotChangeQuality()
        {
            var startingQuality = 80;
            IList<Item> Items = new List<Item> { new Item { Name = GildedRose.SulfurasName, SellIn = 0, Quality = startingQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(startingQuality, Items[0].Quality);
        }
    }
}
