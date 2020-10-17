//using Xunit;
using System;
public class HelpersTest
{
    // [Fact]
    // public void DefaultBuyPrice()
    // {
    //     var helper = new Helper();
    //     var result = helper.buyPrice;
    //     var expected = 10;
    //     //Console.WriteLine("XUnit testing default buy price from Helper. Expected: {0} Result: {1}.", expected, result);
    //     Assert.Equal(expected, result);
    // }

    // [Fact]
    // public void UpgradeDefaultBuyCost()
    // {
    //     var helper = new Helper("Hero", "A Brave Hero", 10, 1);
    //     helper.upgrade = new Upgrade("Copo de Cerveja", "Aumenta o DPS de Ivan, O lutador em 100%", 100);
    //     var result = helper.upgrade.buyCost;
    //     var expected = 10;
        
    //     Assert.Equal(expected, result);
    // }

    // [Fact]
    // public void DefaultUpgradeIsUnlocked()
    // {
    //     var helper = new Helper();
    //     helper.upgrade = new Upgrade();
    //     var result = helper.upgrade.unlocked;
    //     var expected = false;

    //     Assert.Equal(expected, result);

    // }

    // [Fact]
    // public void Unlocked_Upgrade_Required_Level_Is_False()
    // {
    //     var helper = new Helper();
    //     helper.quantity = 5;
    //     helper.upgrade = new Upgrade(); // Default Required Level to Unlock is 10
    //     helper.upgrade.SetUnlocked(helper.quantity);

    //     var result = helper.upgrade.unlocked;
    //     var expected = false;

    //     Assert.Equal(expected, result);
    // }

    //     [Fact]
    // public void Unlocked_Upgrade_Required_Level_Is_True()
    // {
    //     var helper = new Helper();
    //     helper.quantity = 10;
    //     helper.upgrade = new Upgrade(); // Default Required Level to Unlock is 10
    //     helper.upgrade.SetUnlocked(helper.quantity);

    //     var result = helper.upgrade.unlocked;
    //     var expected = true;

    //     Assert.Equal(expected, result);
    // }

    // [Fact]
    // public void OnUpgrade_Upgrade()
    // {
    //     var helper = new Helper(); // Production value is 1
    //     helper.upgrade = new Upgrade(true); // set default unlocked
    //     helper.upgrade.effect = 100;
    //     //helper.upgrade.SetUnlocked(10); // Set level 10 required to Unlock the Upgrade (Upgrade is default false)

    //     helper.OnUpgrade(helper.upgrade);

    //     var result = helper.productionValue;
    //     var expected = 101; // productionValue Inicial + upgrade default value (1 + 100)

    //     Assert.Equal(expected, result);
    // }


}