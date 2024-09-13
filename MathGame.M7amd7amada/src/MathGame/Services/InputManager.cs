namespace MathGame.Services;

public class InputManager : IInputManager
{
    public (int answer, bool isInteger) TakeUserAnswer()
    {
        bool isInteger = int.TryParse(Console.ReadLine(), out int answer);
        return (answer, isInteger);
    }

    public Operator TakeUserOperator()
    {
        while (true)
        {
            Console.Write($"Choose a menu option using your keyboard: ");
            if (int.TryParse(Console.ReadLine(), out int input)
                && Operator.List.Select(x => x.Value).Contains(input))
            {
                Console.WriteLine();
                Operator.TryFromValue(input, out Operator op);
                return op;
            }
            Console.WriteLine("Please enter a valid operator option!\n");
        }
    }

    public Command TakeUserCommand()
    {
        while (true)
        {
            Console.Write($"Choose a menu option using your keyboard: ");
            if (int.TryParse(Console.ReadLine(), out int input)
                && Command.List.Select(x => x.Value).Contains(input))
            {
                Console.WriteLine();
                Command.TryFromValue(input, out Command command);
                return command;
            }
            Console.WriteLine("Please enter a valid command option!\n");
        }
    }
}