using MathGame.Services;

using Microsoft.Extensions.DependencyInjection;

namespace MathGame;

public class Program
{
    public static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IDisplayManager, DisplayManager>()
            .AddScoped<IInputManager, InputManager>()
            .AddScoped<IGameRepository, GameRepository>()
            .AddScoped<ICommandHandler, CommandHandler>()
            .AddScoped<IOperatorHandler, OperatorHandler>()
            .AddScoped<IGameManager, GameManager>()
            .BuildServiceProvider();

        var game = serviceProvider.GetRequiredService<IGameManager>();

        game.StartGame();
    }
}