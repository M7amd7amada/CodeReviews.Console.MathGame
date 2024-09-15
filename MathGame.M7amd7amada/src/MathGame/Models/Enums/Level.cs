using Ardalis.SmartEnum;

namespace MathGame.Models.Enums;

public class Level(string name, int value, int leftOperandDigit, int rightOperandDigit) : SmartEnum<Level>(name, value)
{
    public static readonly Level One = new(nameof(One), 1, 1, 1);
    public static readonly Level Two = new(nameof(Two), 2, 2, 1);
    public static readonly Level Three = new(nameof(Three), 3, 3, 1);
    public static readonly Level Four = new(nameof(Four), 4, 2, 2);
    public static readonly Level Five = new(nameof(Five), 5, 3, 2);
    public static readonly Level Six = new(nameof(Six), 6, 3, 3);

    public int LeftOperandDigit { get; set; } = leftOperandDigit;
    public int RightOperandDigit { get; set; } = rightOperandDigit;
}