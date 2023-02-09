namespace Banking.UnitTests.BonusCalculations;
public class StandardBonusCalculatorTestsOutsideBusinessHours
{
    private StandardBonusCalculator _calculator;

    public StandardBonusCalculatorTestsOutsideBusinessHours()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);
        _calculator = new StandardBonusCalculator(stubbedClock.Object);
    }

    [Fact]
    public void UnderCutoffGetNoBonus()
    {

        var bonus = _calculator.GetDepositBonusFor(4999.99M, 100);

        Assert.Equal(0, bonus);
    }

    [Fact]
    public void AtCutoffGetNoBonus()
    {

        var bonus = _calculator.GetDepositBonusFor(5000M, 100);

        Assert.Equal(0, bonus);
    }
}
