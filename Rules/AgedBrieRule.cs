namespace RefactoringPractice.Rules
{
    public class AgedBrieRule : ItemRule
    {
        public override bool Matches(ItemProxy item) => item?.Name == ItemNames.AgedBrie;

        public override void AdjustQuality(ItemProxy item)
        {
            item.IncrementQuality();
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.IncrementQuality();
        }
    }
}