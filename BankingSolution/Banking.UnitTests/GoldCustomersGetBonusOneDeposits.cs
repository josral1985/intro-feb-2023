namespace Banking.UnitTests;
public class GoldCustomersGetBonusOneDeposits
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        // When
        account.Deposit(amountToDeposit); // <--- System  Under Test


        // Then
        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
    }
}
