using System.Text;

namespace CSharpSyntax;

public class CreatingAndInitializingTypes
{
    string thingy = "Birds";

    [Fact]
    public void UsingLiteralsToCreateInstancesOfTypes()
    {
        // local variabled -- variables that are declared inside a method, or property
        string myName = "Jose";
        char mi = 'M';

        bool isVendor = true;

        int myAge = 37;
        bool isLegalAgeToDrink = myAge >= 21;

        Assert.Equal("Jose", myName);
        Assert.Equal(37, myAge);

        Taco food = new Taco();
    }

    [Fact]
    public void ImplictlyTypedLocalVarials()
    {
        //for local variables only, and you must init the variable
        var myAge = 21;

        var myName = "Jose";

        var favFood = new Taco();

        var myPay = 25.23M;

        Taco lunch = new();
        Assert.IsType<Taco>(lunch);

    }

    [Fact]
    public void CurlyBracesCreateScopes()
    {
        Assert.Equal("Birds", thingy);
        var message = "";

        var age = 22;
        if (age >= 21)
        {
            message = "old enough";
        }

        Assert.Equal(message, "old enough");
    }

    [Fact]
    public void MutableStringsWithStringBuilder()
    {
        var message = new StringBuilder();

        foreach(var num in Enumerable.Range(1, 10000))
        {
            message.Append(num.ToString() + ", ");
        }

        Assert.True(message.ToString().StartsWith("1, 2, 3, 4"));
    }

    [Fact]
    public void MoreAboutStrings()
    {
        var name = "Bob";
        var age = 33;

        var message = "the name is " + name + " and the age is " + age + ".";
        var message2 = string.Format("the name is {0} and the age is {1} (again, name: {0}", name, age);
        var pay = 120_000.00M;
        var m3 = $"{name} makes {pay:c} a year";
    }

    [Fact]
    public void DoingConversionOnTypes()
    {
        string myPay = "10000.83Tacos";

        //try
        //{
        //    decimal payAsNumber = decimal.Parse(myPay);
        //    Assert.Equal(10_000.83M, payAsNumber);
        //}
        //catch (FormatException)
        //{
        //    //that didn't work
        //}

        if(decimal.TryParse(myPay, out decimal payAsNumber))
        {
            Assert.Equal(10_000.83M, payAsNumber);
        }
        else
        {
            Assert.True(false);
        }



    }
}

public class Taco
{

}

public class TransitoryPolicyCommuterRecord { }