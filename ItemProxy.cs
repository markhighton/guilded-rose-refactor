namespace RefactoringPractice
{
    public class ItemProxy
    {
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;
        public string Name => _item.Name;

        private readonly Item _item;

        public ItemProxy(Item item)
        {
            _item = item;
        }

        public void IncrementQuality()
        {
            if(_item.Quality >= 50)
                return;

            _item.Quality++;
        }
        public void DecrementQuality()
        { 
            if(_item.Quality <= 0)
                return;

            _item.Quality--;
        }

        public void DecrementSellIn() => _item.SellIn--;

        public void ResetQuality() => _item.Quality = 0;
    }
}