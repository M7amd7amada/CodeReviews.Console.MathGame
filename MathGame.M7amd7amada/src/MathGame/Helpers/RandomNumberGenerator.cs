namespace MathGame.Helpers;

public static class RandomNumberGenerator
{
    private static readonly Random Random = new();

    public static int GenerateOneDigitRandomNumber()
    {
        return Random.Next(0, 10);
    }

    public static int GenerateTwoDigitRandomNumber()
    {
        return Random.Next(10, 100);
    }

    public static int GenerateThreeDigitRandomNumber()
    {
        return Random.Next(100, 1000);
    }

    public static int GenerateRandomNumber(int min, int max)
    {
        return Random.Next(min, max);
    }
}