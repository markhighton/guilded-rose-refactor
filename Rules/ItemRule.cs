namespace RefactoringPractice.Rules
{
    public abstract class ItemRule 
    {
        public abstract bool Matches(ItemProxy item);
        public void UpdateItem(ItemProxy item)
        {
            AdjustQuality(item);
            AdjustSellIn(item);

            if (item.SellIn < 0)
            {
                AdjustQualityForNegativeSellIn(item);
            }
        }
        public abstract void AdjustQuality(ItemProxy item);
        public abstract void AdjustSellIn(ItemProxy item);
        public abstract void AdjustQualityForNegativeSellIn(ItemProxy item);
    }
}
