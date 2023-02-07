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
}

public class Taco
{

}
