using MathGame.Models;

namespace MathGame.Services.Interfaces;

public interface IGameRepository
{
    List<Game> GetAllGames();
    void AddGame(Game game);
    List<Game> GetTopScores();
    List<Game> GetTopTime();
}