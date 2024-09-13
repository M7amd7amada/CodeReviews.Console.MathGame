using System.Windows.Input;

namespace MathGame.Services;

public class GameManager(IDisplayManager displayHandler, IInputManager inputManager, ICommandHandler handler) : IGameManager
{
    public void StartGame()
    {
        displayHandler.DisplayWelcomeMessage();
        displayHandler.DisplayCommandsMenu();
        var command = inputManager.TakeUserCommand();
        handler.Handle(command);
    }
}
