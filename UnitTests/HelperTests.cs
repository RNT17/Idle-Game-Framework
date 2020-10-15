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
    // Testar requiredLevel
    // Testar effect
    [Fact]
    public void UpgradeRequiredLevel()
    {
        var helper = new Helper();

        //Assert.Equal(expected, result);
    }
}