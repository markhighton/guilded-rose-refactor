using System;
using System.Text;

namespace RefactoringPractice.Rules
{
    public interface IItemRule
    {
        bool Matches(ItemProxy item);
        void UpdateItem(ItemProxy item);
        void AdjustQuality(ItemProxy item);
        void AdjustSellIn(ItemProxy item);
        void AdjustQualityForNegativeSellIn(ItemProxy item);
    }

    public abstract class ItemRule : IItemRule
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
