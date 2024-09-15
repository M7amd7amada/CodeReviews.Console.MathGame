using Ardalis.SmartEnum;

namespace MathGame.Models.Enums;

public class Command(string name, int value) : SmartEnum<Command>(name, value)
{
    public static readonly Command PlayGame = new("Play Game", 1);
    public static readonly Command ViewHistory = new("View History", 2);
    public static readonly Command TopScores = new("Top Scores", 3);
    public static readonly Command TopTime = new("Top Time", 4);

    public static readonly Command Exit = new(nameof(Exit), 0);

}