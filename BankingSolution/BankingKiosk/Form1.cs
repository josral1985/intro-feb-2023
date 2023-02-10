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
        var amount = decimal.Parse(amountInput.Text);
        _account.Deposit(amount);
        this.Text = $"You have a balance of {_account.GetBalance():c} currently";

    }

    private void withdrawBtn_Click(object sender, EventArgs e)
    {
        var amount = decimal.Parse(amountInput.Text);
        _account.Withdraw(amount);
        this.Text = $"You have a balance of {_account.GetBalance():c} currently";
    }
}
