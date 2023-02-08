int breakMinutesAsInt;
TimeSpan songLengthAsTimeSpan;

/*
 making sure the input are correct
 */

while (true)
{
    Console.WriteLine("How long is the break: ");
    if (int.TryParse(Console.ReadLine(), out breakMinutesAsInt))
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
    Console.WriteLine("How long is the song (mm:ss): ");
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
var endOfBreak = DateTimeOffset.Now.AddMinutes(breakMinutesAsInt);
var startSong = endOfBreak - songLengthAsTimeSpan;
var isPlaying = false;
var consoleBGColor = Console.BackgroundColor;

while (true)
{
    var currentTime = DateTimeOffset.Now;
    Console.WriteLine($"Current Time: {currentTime:T}");
    Console.WriteLine($"Break will end at: {endOfBreak:T}");
    Console.WriteLine($"You will start song at {startSong:T}");
    
    //Countdown to end of break
    var minsRemaining = (endOfBreak - currentTime);
    Console.WriteLine($"Your break will end in {minsRemaining.Minutes}:{minsRemaining.Seconds}");

    //Countdown to start playing the song
    if(currentTime > startSong)
    {
        isPlaying = true;
    }
    else
    {
        var cDownToPlay = startSong - currentTime;
        Console.WriteLine($"Time to start the song in {cDownToPlay.Minutes}:{cDownToPlay.Seconds}");
    }
    
    if (currentTime >= endOfBreak) break;

    if (isPlaying)
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
    }

    Thread.Sleep(100);
    Console.Clear();
}
Console.BackgroundColor = consoleBGColor;
Console.Clear();
Console.WriteLine($"Break Over!");
