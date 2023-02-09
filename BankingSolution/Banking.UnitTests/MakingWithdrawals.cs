using Xunit.Sdk;

namespace Banking.UnitTests;
public class MakingWithdrawals
{
    private BankAccount _account;
    private decimal _openingBalance;

    public MakingWithdrawals()
    {
        _account = new BankAccount(new Mock<ICanCalculateAccountBonuses>().Object);
        _openingBalance = _account.GetBalance();
    }

    [Theory]
    [InlineData(100)]
    [InlineData(183.23)]
    public void MakingAWithdrawalDecreasesBalance(decimal amountToWithdraw)
    {
        // Given
        //var account = new BankAccount();
        //var openingBalance = account.GetBalance();

        // When
        _account.Withdraw(amountToWithdraw);


        // Then
        Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());

    }

    [Fact]
    public void OverDraftIsNotAllowedBalanceStaysTheSame()
    {
        //GIVEN
        //var account = new BankAccount();
        //var openingBalance = account.GetBalance();
        var amountToWithdraw = _openingBalance + .01M;

        //WHEN
        try
        {
            _account.Withdraw(amountToWithdraw);
        }
        catch (AccountOverdraftException)
        {
            //was expecting that... carry on
        }

        //THEN
        Assert.Equal(_openingBalance, _account.GetBalance());
    }

    [Fact]
    public void OverdraftThrowsException()
    {
        Assert.Throws<AccountOverdraftException>(() =>
        _account.Withdraw(_openingBalance + 0.1M)
        );
    }

    [Fact]
    public void CanTakeEntireBalance()
    {
        //GIVEN
        //var account = new BankAccount();

        //WHEN
        _account.Withdraw(_account.GetBalance());

        //THEN
        Assert.Equal(0, _account.GetBalance());
    }
}
