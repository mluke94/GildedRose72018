using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public const string AgedBrieName = "Aged Brie";
        public const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
        public const string SulfurasName = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        QualityUpdaterFactory qualityUpdaterFactory;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            qualityUpdaterFactory = new QualityUpdaterFactory();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var qualityUpdater = qualityUpdaterFactory.GetQualityUpdater(item.Name);
                qualityUpdater.UpdateQuality(item);
            }
        }
    }
}
