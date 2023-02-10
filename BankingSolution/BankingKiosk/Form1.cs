using Banking.Domain;

namespace BankingKiosk;

public partial class Form1 : Form
{
    BankAccount _account;
    public Form1()
    {
        InitializeComponent();
        _account = new BankAccount(new StandardBonusCalculator(new StandardBusinessClock(new SystemTime())));
        this.Text = $"You have a balance of {_account.GetBalance():c} currently";
    }

    private void depositBtn_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Deposit);

    }
    private void withdrawBtn_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Withdraw);
    }

    private void DoTransaction(Action<decimal> op)
    {
        try
        {
            var amount = decimal.Parse(amountInput.Text);
            //_account.Deposit(amount);
            op(amount);
            UpdateBalanceDisplay();
        }
        catch (FormatException)
        {
            var message = "Enter a number, you moron";
            DisplayTransactionError(message);
        }
        catch (AccountOverdraftException)
        {
            var message = "You don't have enough money, duder";
            DisplayTransactionError(message);
        }
        catch (NoNegativeNumbersAllowedException)
        {
            DisplayTransactionError("No Negative Numbers Allowed!");
        }
        finally
        {
            //run this if there is an error, of it there isn't a error. Always
            amountInput.SelectAll(); //select all the text in the input
            amountInput.Focus();    //put the cursor there.
        }
    }

    private static void DisplayTransactionError(string message)
    {
        MessageBox.Show(message, "Error on transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void UpdateBalanceDisplay()
    {
        //:c -> formats it to currency
        this.Text = $"You have a balance of {_account.GetBalance():c} currently";
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //anonymous Function - called Lambda in C#, arrow functions in javascript
        DoTransaction((amount) => MessageBox.Show("You clicked a button, blah " + amount.ToString("c")));
        // Anonymous Delegate
      
        
    }
}
