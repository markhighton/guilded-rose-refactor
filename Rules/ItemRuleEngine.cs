using System.Collections.Generic;

namespace RefactoringPractice.Rules
{
    public class ItemRuleEngine
    {
        private readonly List<ItemRule> _rules;

        public ItemRuleEngine(List<ItemRule> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(ItemProxy item)
        {
            foreach (var itemRule in _rules)
            {
                if (itemRule.Matches(item))
                {
                    itemRule.UpdateItem(item);
                    break;
                }
            }
        }

        public class Builder
        {
            private readonly List<ItemRule> _itemRules = new List<ItemRule>();

            public Builder WithAgedBrieRule()
            {
                _itemRules.Add(new AgedBrieRule());
                return this;
            }

            public Builder WithSulfurasRule()
            {
                _itemRules.Add(new SulfurasRule());
                return this;
            }
            public Builder WithBackstagePassesRule()
            {
                _itemRules.Add(new BackstagePassesRule());
                return this;
            }

            public Builder WithConjuredItemRule()
            {
                _itemRules.Add(new ConjuredItemRule());
                return this;
            }

            public ItemRuleEngine Build()
            {
                _itemRules.Add(new NormalRule());

                return new ItemRuleEngine(_itemRules);
            }
        }

        public static ItemRuleEngine Create()
        {
            var engine = new Builder()
                .WithAgedBrieRule()
                .WithBackstagePassesRule()
                .WithConjuredItemRule()
                .WithSulfurasRule()
                .Build();
            return engine;
        }
    }
}