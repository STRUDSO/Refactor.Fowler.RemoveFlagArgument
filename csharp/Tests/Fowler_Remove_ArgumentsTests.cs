namespace RefactorConditionals.Tests;

public class Fowler_Remove_ArgumentsTests
{
    [Theory]
    [InlineData("MA", 4)]
    [InlineData("ME", 5)]
    [InlineData("NH", 5)]
    public void Regular(string state, int offset)
    {
        var day = 1;
        var anOrder = new DeliveryDateCalculator.Order(state, new DateTime(2010, 1, day));

        var regularDeliveryDate = DeliveryDateCalculator.RegularDeliveryDate(anOrder);

        Assert.Equal(new DateTime(2010, 1, day + offset), regularDeliveryDate);
    }

    [Theory]
    [InlineData("MA", 2)]
    [InlineData("ME", 4)]
    [InlineData("NH", 3)]
    public void Rushed(string state, int offset)
    {
        var day = 1;
        var anOrder = new DeliveryDateCalculator.Order(state, new DateTime(2010, 1, day));

        var regularDeliveryDate = DeliveryDateCalculator.RushDeliveryDate(anOrder);

        Assert.Equal(new DateTime(2010, 1, day + offset), regularDeliveryDate);
    }
}