TimeSpan breakMinutesAsTimeSpan, songLengthAsTimeSpan;

//Iter 1
/*
 making sure the input are correct
 */

while (true)
{
    Console.WriteLine("How long is the break: ");
    var breakTime = "00:" + Console.ReadLine() + ":00";
    if (TimeSpan.TryParse(breakTime, out breakMinutesAsTimeSpan))
    {
        break;
    }
    else
    {
        Console.WriteLine("Please enter how minutes; a number.");
    }
}

while (true)
{
    Console.WriteLine("How long is the song: ");
    var songLength = "00:" + Console.ReadLine();
    if (TimeSpan.TryParse(songLength, out songLengthAsTimeSpan))
    {
        break;
    }
    else
    {
        Console.WriteLine("Please enter MIN:SEC");
    }
}

Console.Clear();
var currentTime = DateTimeOffset.Now;
while (true)
{
    //getting current time
    var endOfBreak = currentTime.AddMinutes(breakMinutesAsTimeSpan.TotalMinutes);
    var startSong = endOfBreak - songLengthAsTimeSpan;

    var minsRemaining = (endOfBreak - DateTimeOffset.Now);

    Console.WriteLine($"Your break will end in {minsRemaining:t}");

    if (DateTimeOffset.Now >= endOfBreak) break;

    Thread.Sleep(100);
    Console.Clear();
}

Console.WriteLine($"Break Over!");
