using FluentAssertions;
using RefactoringPractice;
using RefactoringPractice.Rules;
using Xunit;

namespace RefactoringPracticeTests.ItemManagerTests
{
    public class UpdateQualityTests
    {
        private ItemManager _itemManager;

        [Theory]
        [InlineData(ItemNames.DexterityVest)]
        [InlineData(ItemNames.ElixirOfMongoose)]
        public void Item_quality_degrades_twice_as_fast_when_sell_in_day_has_passed(string itemName)
        {
            _itemManager = new ItemManager(new Item { Name = itemName, Quality = 10, SellIn = -1 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(itemName).Quality;
            updatedQuality.Should().Be(8);
        }


        [Theory]
        [InlineData(ItemNames.AgedBrie)]
        [InlineData(ItemNames.DexterityVest)]
        [InlineData(ItemNames.ElixirOfMongoose)]
        [InlineData(ItemNames.Sulfuras)]
        [InlineData(ItemNames.BackstagePasses)]
        public void Item_quality_is_never_negative(string itemName)
        {
            _itemManager = new ItemManager(new Item { Name = itemName, Quality = 1, SellIn = 1 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(itemName).Quality;
            updatedQuality.Should().BeGreaterOrEqualTo(0);
        }

        [Theory]
        [InlineData(ItemNames.AgedBrie)]
        [InlineData(ItemNames.DexterityVest)]
        [InlineData(ItemNames.ElixirOfMongoose)]
        [InlineData(ItemNames.Sulfuras)]
        [InlineData(ItemNames.BackstagePasses)]
        public void Item_quality_never_exceeds_50(string itemName)
        {
            _itemManager = new ItemManager(new Item { Name = itemName, Quality = 50, SellIn = 2 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(itemName).Quality;
            updatedQuality.Should().BeLessOrEqualTo(50);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(20, 21)]
        public void Aged_brie_increases_in_quality(int quality, int expected)
        {
            _itemManager = new ItemManager(new Item { Name = ItemNames.AgedBrie, Quality = quality, SellIn = 2 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(ItemNames.AgedBrie).Quality;
            updatedQuality.Should().Be(expected);
        }

        [Fact]
        public void Sulfuras_never_decrease_in_quality()
        {
            _itemManager = new ItemManager(new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(ItemNames.Sulfuras).Quality;
            updatedQuality.Should().Be(80);
        }

        [Fact]
        public void Sulfuras_sell_in_days_never_decreases()
        {
            _itemManager = new ItemManager(new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var sellIn = _itemManager.GetByName(ItemNames.Sulfuras).SellIn;
            sellIn.Should().Be(0);
        }

        [Fact]
        public void Backstage_passes_quality_drops_to_zero_after_sell_in_day_passes()
        {
            _itemManager = new ItemManager(new Item { Name = ItemNames.BackstagePasses, Quality = 10, SellIn = -1 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(ItemNames.BackstagePasses).Quality;
            updatedQuality.Should().Be(0);
        }

        [Fact]
        public void Backstage_passes_quality_increase_by_two_when_sell_in_days_is_ten_or_less()
        {
            _itemManager = new ItemManager(new Item { Name = ItemNames.BackstagePasses, Quality = 3, SellIn = 10 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(ItemNames.BackstagePasses).Quality;
            updatedQuality.Should().Be(5);
        }

        [Fact]
        public void Backstage_passes_quality_increase_by_three_when_sell_in_days_is_five_or_less()
        {
            _itemManager = new ItemManager(new Item { Name = ItemNames.BackstagePasses, Quality = 3, SellIn = 5 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(ItemNames.BackstagePasses).Quality;
            updatedQuality.Should().Be(6);
        }

        [Fact]
        public void Conjured_items_degrade_in_quality_twice_as_fast()
        {
            _itemManager = new ItemManager(new Item { Name = ItemNames.ConjuredManaCake, SellIn = 3, Quality = 6 }, ItemRuleEngine.Create());
            _itemManager.UpdateQuality();

            var updatedQuality = _itemManager.GetByName(ItemNames.ConjuredManaCake).Quality;
            updatedQuality.Should().Be(4);
        }

    }
}
