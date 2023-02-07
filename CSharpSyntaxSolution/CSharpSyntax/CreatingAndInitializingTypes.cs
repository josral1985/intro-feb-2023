namespace CSharpSyntax;

public class CreatingAndInitializingTypes
{
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
    }
}

public class Taco
{

}
