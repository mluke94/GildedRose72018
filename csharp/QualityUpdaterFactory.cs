namespace csharp
{
    public class QualityUpdaterFactory
    {
        public IQualityUpdater GetQualityUpdater(string name)
        {
            switch (name)
            {
                case GildedRose.AgedBrieName:
                    return new AgedBrieQualityUpdater();
                case GildedRose.BackstagePassName:
                    return new BackstagePassQualityUpdater();
                case GildedRose.SulfurasName:
                    return new NullQualityUpdater();
                default:
                    return new DefaultQualityUpdater();
            }
        }
    }
}
