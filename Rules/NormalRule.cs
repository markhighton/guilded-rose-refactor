namespace RefactoringPractice.Rules
{
    public class NormalRule : ItemRule
    {
        public override bool Matches(ItemProxy item) => item.Name == ItemNames.ElixirOfMongoose || item.Name == ItemNames.DexterityVest;

        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.DecrementQuality();
        }
    }
}