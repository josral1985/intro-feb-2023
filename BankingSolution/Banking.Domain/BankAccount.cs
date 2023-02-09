namespace Banking.Domain
{
    public enum LoyaltyLevel { Standard, Gold };
    public class BankAccount
    {
        private decimal _balance = 5000m; //State - "Fields" variable.
        public LoyaltyLevel level;
        public void Deposit(decimal amountToDeposit)
        {
            decimal bonus = 0;
            if(level == LoyaltyLevel.Gold)
            {
                bonus = amountToDeposit * .10M;
            }
            _balance += amountToDeposit + bonus;
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
            if (NoOverdraft(amountToWithdraw))
            {
                _balance -= amountToWithdraw;
            }
            else
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