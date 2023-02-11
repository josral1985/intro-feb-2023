
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        var negativeNumbers = new List<int> { };

        var delimiters = new List<char> { ',', '\n' };

        if (numbers == "")
        {
            return 0;
        }

        if (numbers.StartsWith("//"))
        {
            var delim = numbers[2];
            delimiters.Add(delim);
            numbers = numbers.Substring(4);
        }

        var total = 0;
        var pieces = numbers.Split(delimiters.ToArray());

        foreach (var piece in pieces)
        {
            if (piece.StartsWith("-"))
            {
                negativeNumbers.Add(int.Parse(piece));
            }
            total += int.Parse(piece);
        }

        if (negativeNumbers.Count <= 0) return total;

        var message = "Negatives not allowed ";
        for (var i = 0; i < negativeNumbers.Count; i++)
        {
            if (i == negativeNumbers.Count - 1)
            {
                message += negativeNumbers[i];
            }
            else
            {
                message += negativeNumbers[i] + ", ";
            }
        }

        throw new NoNegativeNumbersException(message);

    }
}
