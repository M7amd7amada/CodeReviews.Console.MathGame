using MathGame.Handlers.Interfaces;

namespace MathGame.Handlers;

public class CommandHandler(
    IGameRepository repository,
    IDisplayManager displayManager,
    IInputManager inputManager,
    IOperatorHandler operatorHandler) : ICommandHandler
{
    public void Handle(Command command)
    {
        switch (command.Value)
        {
            case 0:
                Exit();
                break;
            case 1:
                PlayGame();
                break;
            case 2:
                ViewHistory();
                break;
            case 3:
                TopScores();
                break;
            case 4:
                TopTime();
                break;
        };
    }

    private void PlayGame()
    {
        displayManager.DisplayLevelsMenu();
        var level = inputManager.TakeUserLevel();
        displayManager.DisplayOperatorsMenu();
        var op = inputManager.TakeUserOperator();
        operatorHandler.Handle(op, level);
    }

    private void ViewHistory()
    {
        displayManager.DisplayGames(repository.GetAllGames());
    }

    private void TopScores()
    {
        displayManager.DisplayGames(repository.GetTopScores());
    }

    private void TopTime()
    {
        displayManager.DisplayGames(repository.GetTopTime());
    }

    private static void Exit()
    {
        Environment.Exit(0);
    }
}