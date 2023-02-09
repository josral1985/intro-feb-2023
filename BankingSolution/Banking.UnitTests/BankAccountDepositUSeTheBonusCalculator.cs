namespace Banking.UnitTests;
public class BankAccountDepositUSeTheBonusCalculator
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        // Given
        //automate stubbedBonus
        var stubbedBonusCalculator = new Mock<ICanCalculateAccountBonuses>();
        var account = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 118.32M;
        stubbedBonusCalculator.Setup(arbitraryName =>
        arbitraryName.GetDepositBonusFor(openingBalance, amountToDeposit))
            .Returns(42.18M);

        // When
        account.Deposit(amountToDeposit); // <--- System  Under Test


        // Then
        Assert.Equal(openingBalance + amountToDeposit + 42.18M, account.GetBalance());
    }
}
