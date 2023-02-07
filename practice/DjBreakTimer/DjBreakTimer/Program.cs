TimeSpan breakMinutesAsTimeSpan, songLengthAsTimeSpan;

//getting current time
var currentTime = DateTimeOffset.Now;


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


Console.WriteLine($"Start of break is {currentTime:t}");
Console.WriteLine($"Break Length: {breakMinutesAsTimeSpan.TotalMinutes} minutes");


var endOfBreak = currentTime.AddMinutes(breakMinutesAsTimeSpan.TotalMinutes);
Console.WriteLine($"Break ends At: {endOfBreak:t}");


var startSong = endOfBreak - songLengthAsTimeSpan;
Console.WriteLine($"Start Song at: {startSong:T}");

