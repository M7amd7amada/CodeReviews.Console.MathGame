using MathGame.Services.Interface;

namespace MathGame.Services;

public class DisplayHandler : IDisplayHandler
{
    public void DisplayWelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine($"{"",3}Welcome To Math Game!!");
        Console.WriteLine(new string('-', 30));
    }
}