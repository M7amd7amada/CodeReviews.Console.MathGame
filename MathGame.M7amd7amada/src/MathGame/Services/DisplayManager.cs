using MathGame.Models;

using Spectre.Console;

namespace MathGame.Services;

public class DisplayManager : IDisplayManager
{
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
            Console.WriteLine($"[{op.Value}] {op.Name,-15} ({op.Symbol})");
        }
    }

    private static void ListCommands()
    {
        foreach (var command in Command.List.Where(x => x.Value != 0).Order())
        {
            Console.WriteLine($"[{command.Value}] {command.Name}");
        }
    }

    public void DisplayLevelsMenu()
    {
        Console.WriteLine("Levels: \n");
        Console.WriteLine($"{"Value",-6} {"Name",-20} {"Operands",-15}");
        Console.WriteLine(new string('-', 45));

        foreach (var level in Level.List.Order())
        {
            Console.WriteLine($"[{level.Value,-1}]{"",-3} {level.Name,-20} ({level.LeftOperandDigit} # {level.RightOperandDigit})");
        }
    }

    public void DisplayGameStatus(Game game)
    {
        Console.WriteLine($"\nGame Score: {game.Score}\nGame Time: {game.Time}\n");
        Console.WriteLine(new string('-', 60));
    }

    public void DisplayGames(List<Game> games)
    {
        if (games.Count == 0)
        {
            Console.WriteLine("There is no games right now!!\n");
        }
        else
        {
            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Date");
            table.AddColumn("Score");
            table.AddColumn("Time");

            foreach (var game in games)
            {
                table.AddRow($"#{game.Id}", game.GameDate.ToString(), game.Score.ToString(), game.Time.ToString());
            }

            AnsiConsole.Write(table);
        }
    }
}