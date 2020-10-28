namespace RefactoringPractice.Rules
{
    public class SulfurasRule : ItemRule
    {
        public override bool Matches(ItemProxy item) => item?.Name == ItemNames.Sulfuras;

        public override void AdjustQuality(ItemProxy item)
        {
            // do nothing
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            // do nothing
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            // do nothing
        }
    }
}