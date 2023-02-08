
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        var delimeters = new List<char> { ',', '\n'};

        if (numbers == "")
        {
            return 0;
        }

        if (numbers.StartsWith("//"))
        {
            var delim = numbers[2];
            delimeters.Add(delim);
            numbers = numbers.Substring(4);
        }

        var total = 0;
        var pieces = numbers.Split(delimeters.ToArray());

        foreach(var piece in pieces)
        {
            total += int.Parse(piece);
        }

        return total;
    }
}
