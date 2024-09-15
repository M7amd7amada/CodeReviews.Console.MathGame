using MathGame.Models;

namespace MathGame.Services.Interfaces;

public interface IDisplayManager
{
    void DisplayWelcomeMessage();
    void DisplayCommandsMenu();
    void DisplayLevelsMenu();
    void DisplayOperatorsMenu();
    void DisplayGames(List<Game> games);
    void DisplayProblem(MathProblem problem);
}