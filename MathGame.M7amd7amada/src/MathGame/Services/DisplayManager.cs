using MathGame.Models;

namespace MathGame.Services;

public class DisplayManager : IDisplayManager
{
    public void DisplayLevelsMenu()
    {

    }

    public void DisplayProblem(MathProblem problem)
    {
        Console.Write($"{problem.LeftOperand} {(char)problem.Operator} {problem.RightOperand} = ");
    }

    public void DisplayOperatorsMenu()
    {
        Console.WriteLine("Operators: \n");
        ListOperators();
        Console.WriteLine();
    }

    public void DisplayCommandsMenu()
    {
        Console.WriteLine("Commands: \n");
        ListCommands();
        Console.WriteLine($"\n[{Command.Exit.Value}] {Command.Exit.Name}\n");
    }

    public void DisplayWelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine($"{"",3}Welcome To Math Game!!");
        Console.WriteLine(new string('-', 30));
    }

    private static void ListOperators()
    {
        foreach (var op in Operator.List.Order())
        {
            Console.WriteLine($"[{op.Value}] {op.Name,-15} {op.Symbol}");
        }
    }

    private static void ListCommands()
    {
        foreach (var command in Command.List.Where(x => x.Value != 0).Order())
        {
            Console.WriteLine($"[{command.Value}] {command.Name}");
        }
    }

}