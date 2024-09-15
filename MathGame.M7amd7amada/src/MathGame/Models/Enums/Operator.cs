using Ardalis.SmartEnum;

namespace MathGame.Models.Enums;

public class Operator(string name, int value, char symbol) : SmartEnum<Operator>(name, value)
{
    public static readonly Operator Addition = new(nameof(Addition), 1, '+');
    public static readonly Operator Subtraction = new(nameof(Subtraction), 2, '-');
    public static readonly Operator Multiplication = new(nameof(Multiplication), 3, '*');
    public static readonly Operator Division = new(nameof(Division), 4, '/');
    public static readonly Operator Random = new("Random Game", 5, ' ');

    public char Symbol = symbol;
}