namespace RefactoringPractice.Rules
{
    public class BackstagePassesRule : ItemRule
    {
        public override bool Matches(ItemProxy item)
        {
            return item.Name == ItemNames.BackstagePasses;
        }

        public override void AdjustQuality(ItemProxy item)
        {
            item.IncrementQuality();
            if (item.SellIn < 11)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncrementQuality();
            }
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.ResetQuality();
        }
    }
}