using Xunit;
using System;
public class HelpersTest
{
    [Fact]
    public void DefaultBuyPrice()
    {
        var helper = new Helper();
        var result = helper.buyPrice;
        var expected = 10;
        //Console.WriteLine("XUnit testing default buy price from Helper. Expected: {0} Result: {1}.", expected, result);
        Assert.Equal(expected, result);
    }

    // Criar metodos em Helper para testar Upgrade
    // Testar BuyCost Default
    // Testar requiredLevel
    // Testar effect
    [Fact]
    public void UpgradeDefaultBuyCost()
    {
        var helper = new Helper("Hero", "A Brave Hero", 10, 1);
        helper.Upgrade = new Upgrade();
        var result = helper.Upgrade.BuyCost;
        var expected = 0;
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void DefaultUpgradeIsUnlocked()
    {
        var helper = new Helper();
        helper.Upgrade = new Upgrade();
        var result = helper.Upgrade.Unlocked;
        var expected = false;

        Assert.Equal(expected, result);

    }

    [Fact]
    public void Unlocked_Upgrade_Required_Level_Is_False()
    {
        var helper = new Helper();
        helper.Upgrade = new Upgrade(); // Default Required Level to Unlock is 10
        helper.Upgrade.SetUnlocked(5);
        
        var result = helper.Upgrade.Unlocked;
        var expected = false;

        Assert.Equal(expected, result);

    }

}