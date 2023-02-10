namespace Banking.Domain
{
    public class BankAccount
    {
        private decimal _balance = 5000m; //State - "Fields" variable.
        private ICanCalculateAccountBonuses _bonusCalculator;


        // Constructors are for REQUIRED DEPENDENCIES when creating a class.
        public BankAccount(ICanCalculateAccountBonuses bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

        public void Deposit(decimal amountToDeposit)
        {
            GuardNoNegativeAmountsForTransactions(amountToDeposit);
            // write the code you wish you had
            decimal bonus = _bonusCalculator.GetDepositBonusFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }

        private static void GuardNoNegativeAmountsForTransactions(decimal amountToDeposit)
        {
            if (amountToDeposit < 0)
            {
                throw new NoNegativeNumbersAllowedException();
            }
        }

        public decimal GetBalance()
        {
            //return -42; // fake - force a failure
            //return 5000; // hardcode it! "Sliming"
            return _balance; // using a class variable
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            //throw new NotImplementedException();
            GuardNoNegativeAmountsForTransactions(amountToWithdraw);
            GuardNoOverdraft(amountToWithdraw);

            _balance -= amountToWithdraw;

        }

        private void GuardNoOverdraft(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new AccountOverdraftException();
            }
        }

        private bool NoOverdraft(decimal amountToWithdraw)
        {
            return amountToWithdraw <= _balance;
        }
    }
}