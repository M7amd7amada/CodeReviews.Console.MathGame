namespace MathGame.Services;

public class CommandHandler(IGameRepository repository, IDisplayManager displayManager, IInputManager inputManager, IOperatorHandler operatorHandler) : ICommandHandler
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
            default:
                throw new ArgumentOutOfRangeException(nameof(command), "Invalid operation");
        };
    }

    private void PlayGame()
    {
        displayManager.DisplayOperatorsMenu();
        var op = inputManager.TakeUserOperator();
        operatorHandler.Handle(op);
    }

    private void ViewHistory()
    {
        repository.GetAllGames();
    }

    private void TopScores()
    {
        repository.GetTopScores();
    }

    private static void Exit()
    {
        Environment.Exit(0);
    }
}