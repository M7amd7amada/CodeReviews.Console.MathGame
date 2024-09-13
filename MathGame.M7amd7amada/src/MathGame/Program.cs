using MathGame.Services;
using MathGame.Services.Interface;

using Microsoft.Extensions.DependencyInjection;

namespace MathGame;

public class Program
{
    public static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IDisplayHandler, DisplayHandler>()
            .BuildServiceProvider();

        var displayHandler = serviceProvider.GetRequiredService<IDisplayHandler>();

        displayHandler.DisplayWelcomeMessage();
    }
}