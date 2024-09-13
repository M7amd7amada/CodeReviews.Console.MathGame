namespace MathGame.Models;

public class Game(Expression expression)
{
    private static int s_idCount = 1;

    public int Id { get; } = s_idCount++;
    public DateTime GameDate { get; } = DateTime.Now;
    public int Score { get; set; } = 0;
    public Expression Expression { get; private set; } = expression;
    public int? Result { get; set; } = default!;
    public TimeSpan Time { get; set; } = default!;
}
