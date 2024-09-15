
using MathGame.Models;

namespace MathGame.Services;

public class GameRepository : IGameRepository
{
    private readonly List<Game> _games = [];

    public void AddGame(Game game)
    {
        _games.Add(game);
    }

    public List<Game> GetAllGames()
    {
        return _games;
    }

    public List<Game> GetTopScores()
    {
        return [.. _games.OrderBy(x => x.Score)];
    }

    public List<Game> GetTopTime()
    {
        return [.. _games.OrderBy(x => x.Time)];
    }
}