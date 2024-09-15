namespace MathGame.Models;

public class Game
{
    private static int s_idCount = 1;

    public int Id { get; } = s_idCount++;
    public DateTime GameDate { get; } = DateTime.UtcNow;
    public int Score { get; set; } = 0;
    public long Time { get; set; } = default!;
}
