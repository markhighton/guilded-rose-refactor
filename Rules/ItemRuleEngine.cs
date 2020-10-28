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

        public static ItemRuleEngine Create()
        {
            var rules = new List<ItemRule>
            {
                new AgedBrieRule(),
                new BackstagePassesRule(),
                new NormalRule(),
                new SulfurasRule(),
                new ConjuredItemRule(),
            };

            return new ItemRuleEngine(rules);
        }
    }
}