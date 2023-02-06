using Finger;

Console.Write("What is your Status: ");
string? status = Console.ReadLine();

if (status != null)
{
    StatusMessage myStatus = new StatusMessage(status, DateTimeOffset.Now);
    Console.WriteLine($"You said your status was {myStatus.Status} at {myStatus.When:T}");
}
else
{
    Console.WriteLine("Sorry, Cannot have a null status");
}

