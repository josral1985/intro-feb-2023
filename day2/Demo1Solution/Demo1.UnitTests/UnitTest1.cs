namespace Demo1.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //throw new Exception();
        }

        [Fact]
        public void CanAddTwoNumbers() 
        {
            //Given
            int a = 10, b = 20, c;
            //When
            c = a + b;
            //Then

            Assert.Equal(30, c);
        }
    }
}