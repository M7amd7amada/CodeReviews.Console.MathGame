using MathGame.Models;
using MathGame.Helpers;
using System.Diagnostics;

namespace MathGame.Services;

public class OperatorHandler(IDisplayManager displayManager, IInputManager inputManager) : IOperatorHandler
{
    private readonly Stopwatch _stopwatch = new();
    public void Handle(Operator op)
    {
        switch (op.Name)
        {
            case nameof(Operator.Addition):
                GenerateProblems(Operator.Addition);
                break;
            case nameof(Operator.Subtraction):
                GenerateProblems(Operator.Subtraction);
                break;
            case nameof(Operator.Multiplication):
                GenerateProblems(Operator.Multiplication);
                break;
            case nameof(Operator.Division):
                GenerateProblems(Operator.Division);
                break;
            case nameof(Operator.Random):
                GenerateProblems(GetRandomOperator());
                break;
            default:
                throw new InvalidOperationException("Invalid operator");
        }
    }

    private static Operator GetRandomOperator()
    {
        var operators = new[] { Operator.Addition, Operator.Subtraction, Operator.Multiplication, Operator.Division };
        var randomIndex = RandomNumberGenerator.GenerateRandomNumber(0, operators.Length - 1);
        return operators[randomIndex];
    }

    private void GenerateProblems(Operator op)
    {
        Game game = new();
        int answer = 0;
        _stopwatch.Start();
        for (int i = 0; i < 10; i++)
        {
            bool isInteger = false;
            var problem = GenerateProblem(op);
            while (!isInteger)
            {
                displayManager.DisplayProblem(problem);
                (answer, isInteger) = inputManager.TakeUserAnswer();
                if (!isInteger)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Insert Valid Number!!");
                    Console.ResetColor();
                }
            }
            problem.UserAnswer = answer;
            game.Problem = problem;
            if (problem.IsCorrectAnswer())
            {
                game.Score++;
            }
        }
        _stopwatch.Stop();
        game.Time = _stopwatch.ElapsedMilliseconds / 1000;
        Console.WriteLine("Score " + game.Score);
        Console.WriteLine("Time " + game.Time);
    }

    private static MathProblem GenerateProblem(Operator op)
    {
        var leftOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
        var rightOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);

        return op.Name switch
        {
            nameof(Operator.Addition) => new MathProblem(leftOperand, Operator.Addition.Symbol, rightOperand, leftOperand + rightOperand, null),
            nameof(Operator.Subtraction) => new MathProblem(leftOperand, Operator.Subtraction.Symbol, rightOperand, leftOperand - rightOperand, null),
            nameof(Operator.Multiplication) => new MathProblem(leftOperand, Operator.Multiplication.Symbol, rightOperand, leftOperand * rightOperand, null),
            nameof(Operator.Division) => GenerateDivisionProblem(leftOperand, rightOperand),
            _ => throw new InvalidOperationException("Unknown operator")
        };
    }

    private static MathProblem GenerateDivisionProblem(int leftOperand, int rightOperand)
    {
        while (!(rightOperand != 0 && leftOperand % rightOperand == 0))
        {
            leftOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
            rightOperand = RandomNumberGenerator.GenerateRandomNumber(1, 9);
        }

        return new MathProblem(leftOperand, Operator.Division.Symbol, rightOperand, leftOperand / rightOperand, null);
    }
}