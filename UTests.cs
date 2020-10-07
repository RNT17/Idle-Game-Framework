using Xunit;

public class UTests
{
    [Fact]
    public void DefaultBuyPrice()
    {
        var helper = new Helper();
        var result = helper.buyPrice;
        var expected = 10;
        Assert.Equal(result, expected);
    }



    // ========== Fact ===========//
    // [Fact]
    // public void PassingTest()
    // {
    //     Assert.Equal(4, Add(2, 2));
    // }

    // [Fact]
    // public void FailingTest()
    // {
    //     Assert.Equal(5, Add(2, 2));
    // }

    // int Add(int x, int y)
    // {
    //     return x + y;
    // }

    // ========== Theory ===========//

    // [Theory]
    // [InlineData(3)]
    // [InlineData(5)]
    // //[InlineData(6)]
    // public void MyFirstTheory(int value)
    // {
    //     Assert.True(IsOdd(value));
    // }

    // bool IsOdd(int value)
    // {
    //     return value % 2 == 1;
    // }
}