namespace MathGame.Services;

public class GameManager(
    IDisplayManager displayManager,
    IInputManager inputManager,
    ICommandHandler handler) : IGameManager
{
    public void StartGame()
    {
        displayManager.DisplayWelcomeMessage();
        while (true)
        {
            Console.WriteLine();
            displayManager.DisplayCommandsMenu();
            var command = inputManager.TakeUserCommand();
            handler.Handle(command);
        }
    }
}
