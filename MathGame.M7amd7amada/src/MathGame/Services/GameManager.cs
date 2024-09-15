using System.Windows.Input;

namespace MathGame.Services;

public class GameManager(IDisplayManager displayHandler, IInputManager inputManager, ICommandHandler handler) : IGameManager
{
    public void StartGame()
    {
        displayHandler.DisplayWelcomeMessage();
        while (true)
        {
            System.Console.WriteLine();
            displayHandler.DisplayCommandsMenu();
            var command = inputManager.TakeUserCommand();
            handler.Handle(command);
        }
    }
}
