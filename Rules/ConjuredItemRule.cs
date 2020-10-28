namespace RefactoringPractice.Rules
{
    public class ConjuredItemRule : ItemRule
    {
        public override bool Matches(ItemProxy item)
        {
            return item.Name.ToLower().Contains("conjured");
        }

        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
        }
    }
}