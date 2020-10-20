using Xunit;

public class HelpersTests
{
    /*
        Default BuyPrice is 10
    */
    [Fact]
    public void DefaultBuyPrice()
    {
        var helper = new Helper();
        var result = helper.buyPrice;
        var expected = 10;
        Assert.Equal(expected, result);
    }

    /*
        One Helper id is 1
    */
    [Fact] 
    public void OneHelperId()
    {
        var expected = 1;
        var helper = new Helper();
        var result = helper.id;
        Assert.Equal(expected, result);
    }

}
