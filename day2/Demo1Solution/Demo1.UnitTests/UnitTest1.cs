namespace Demo1.UnitTests;

public class UnitTest1
{
    //Fact does not accept params; makes sense
    [Fact]
    public void CanAddTwoNumbers() 
    {
        //Given (arrange)
        int a = 10, b = 20, c;
        
        //When (act)
        c = a + b; // Ths is the thing you are actually testing.
        
        //Then (assert)
        Assert.Equal(30, c);
    }

    //Theory does accept params, by inlinedata or other ways to pass data

    [Theory]
    [InlineData(2,2,4)]
    [InlineData(8,2,10)]
    [InlineData(40,2,42)]
    public void CanAddTwoNumbersTheory(int a, int b, int expected)
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }
}