using System.Collections.Generic;
using System.Linq;
using RefactoringPractice.Rules;

namespace RefactoringPractice
{
    public class ItemManager
    {
        private readonly List<Item> _items;
        private readonly ItemRuleEngine _itemRuleEngine;
        public IReadOnlyList<ItemProxy> Items => _items?.Select(i => new ItemProxy(i)).ToList();

        public ItemManager(Item item, ItemRuleEngine ruleEngine) : this(new List<Item> {item}, ruleEngine) { }
        
        public ItemManager(List<Item> items, ItemRuleEngine ruleEngine)
        {
            _items = items;
            _itemRuleEngine = ruleEngine;
        }

        public ItemProxy GetByName(string name) => Items.FirstOrDefault(i => i.Name == name);

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateQuality(item);
            }
        }
        public void UpdateQuality(ItemProxy item) => _itemRuleEngine.ApplyRules(item);

        //public void UpdateQuality()
        //{
        //    for (var i = 0; i < Items.Count; i++)
        //    {
        //        if (_items[i].Name != "Aged Brie" && _items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //        {
        //            if (_items[i].Quality > 0)
        //            {
        //                if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                {
        //                    if (_items[i].Name != ItemNames.ConjuredManaCake)
        //                    { 
        //                        _items[i].Quality = _items[i].Quality - 1;
        //                    }
        //                    else
        //                    {
        //                        _items[i].Quality = _items[i].Quality - 2;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (_items[i].Quality < 50)
        //            {
        //                _items[i].Quality = _items[i].Quality + 1;

        //                if (_items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //                {
        //                    if (_items[i].SellIn < 11)
        //                    {
        //                        if (_items[i].Quality < 50)
        //                        {
        //                            _items[i].Quality = _items[i].Quality + 1;
        //                        }
        //                    }

        //                    if (_items[i].SellIn < 6)
        //                    {
        //                        if (_items[i].Quality < 50)
        //                        {
        //                            _items[i].Quality = _items[i].Quality + 1;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
        //        {
        //            _items[i].SellIn = _items[i].SellIn - 1;
        //        }

        //        if (_items[i].SellIn < 0)
        //        {
        //            if (_items[i].Name != "Aged Brie")
        //            {
        //                if (_items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //                {
        //                    if (_items[i].Quality > 0)
        //                    {
        //                        if (_items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                        {
        //                            _items[i].Quality = _items[i].Quality - 1;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    _items[i].Quality = _items[i].Quality - _items[i].Quality;
        //                }
        //            }
        //            else
        //            {
        //                if (_items[i].Quality < 50)
        //                {
        //                    _items[i].Quality = _items[i].Quality + 1;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}