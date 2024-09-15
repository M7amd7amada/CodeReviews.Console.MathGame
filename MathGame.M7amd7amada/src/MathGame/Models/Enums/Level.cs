using Ardalis.SmartEnum;

namespace MathGame.Models.Enums;

public class Level(string name, int value) : SmartEnum<Level>(name, value)
{
    public static readonly Level One = new(nameof(One), 1);
    public static readonly Level Two = new(nameof(Two), 2);
    public static readonly Level Three = new(nameof(Three), 3);
    public static readonly Level Four = new(nameof(Four), 4);
    public static readonly Level Five = new(nameof(Five), 5);
    public static readonly Level Six = new(nameof(Six), 6);
}