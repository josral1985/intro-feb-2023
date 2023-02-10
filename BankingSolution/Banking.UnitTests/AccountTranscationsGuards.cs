namespace Banking.UnitTests;
public class AccountTranscationsGuards
{
    //we have a defect (there will usually be some ID associated with it)

    // step 1. write another test that demonstrates how it SHOULD work if the defect is fixed. it should fail.
    [Fact]
    public void NegativeNumbersNotAllowed()
    {
        var stubbedBonusCalculator = new Mock<ICanCalculateAccountBonuses>();
        var account = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();

        account.Deposit(-1000);

        Assert.Throws<NoNegativeNumbersAllowedException>(() => account.Deposit(-1000));
        Assert.Equal(openingBalance, account.GetBalance());
    }

}

