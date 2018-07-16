namespace csharp
{
    internal class AgedBrieQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn = item.SellIn - 1;

            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}