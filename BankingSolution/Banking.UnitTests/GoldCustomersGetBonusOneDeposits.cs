namespace Banking.UnitTests;
public class GoldCustomersGetBonusOneDeposits
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        var account = new BankAccount();
        account.level = LoyaltyLevel.Gold;

        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
    }
}
