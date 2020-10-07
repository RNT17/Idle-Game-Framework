using Xunit;
public class HelpersTest
{
    [Fact]
    public void DefaultBuyPrice()
    {
        var helper = new Helper();
        var result = helper.buyPrice;
        var expected = 10;
        Assert.Equal(result, expected);
    }
}