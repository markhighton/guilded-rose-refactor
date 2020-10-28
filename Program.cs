using System;
using System.Collections.Generic;
using RefactoringPractice.Rules;

namespace RefactoringPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var itemRepository = new ItemRepository();
            var items = itemRepository.GetItems();
            var ruleEngine = ItemRuleEngine.Create();
            var itemManager = new ItemManager(items, ruleEngine);
            itemManager.UpdateQuality();

            Console.ReadKey();

        }


    }
}
