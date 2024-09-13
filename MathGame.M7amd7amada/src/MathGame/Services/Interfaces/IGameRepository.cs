using MathGame.Models;

namespace MathGame.Services.Interfaces;

public interface IGameRepository
{
    List<Game> GetAllGames();
    void AddGame();
    List<Game> GetTopScores();
}