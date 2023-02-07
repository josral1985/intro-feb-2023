TimeSpan breakMinutesAsTimeSpan, songLengthAsTimeSpan;

//getting current time
var currentTime = DateTimeOffset.Now;


//Iter 1
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

//getting current Time
//Console.WriteLine("CurrentTime: " + currentTime);

Console.WriteLine("Start of break is " + currentTime.Hour + ":" + currentTime.Minute + " and your break is " + breakMinutesAsTimeSpan.Minutes + " minutes long");
Console.WriteLine("The song is " + songLengthAsTimeSpan.Minutes + " minutes and " + songLengthAsTimeSpan.Seconds + " seconds long");

var endOfBreak = currentTime.AddMinutes(breakMinutesAsTimeSpan.TotalMinutes);
Console.WriteLine("End of Break: " + endOfBreak.Hour + ":" + endOfBreak.Minute + ":" + endOfBreak.Second);

var startSong = (endOfBreak - songLengthAsTimeSpan) - currentTime;

Console.WriteLine("start the song in: " + startSong.Minutes + " minutes and " + startSong.Seconds + " second(s)");
