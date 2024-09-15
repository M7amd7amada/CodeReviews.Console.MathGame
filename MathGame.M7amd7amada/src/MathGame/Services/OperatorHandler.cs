using MathGame.Models;
using MathGame.Helpers;
using System.Diagnostics;

namespace MathGame.Services;

public class OperatorHandler(IDisplayManager displayManager, IInputManager inputManager, IGameRepository gameRepository) : IOperatorHandler
{
    private readonly Stopwatch _stopwatch = new();
    public void Handle(Operator op, Level level)
    {
        switch (op.Name)
        {
            case nameof(Operator.Addition):
                GenerateProblems(Operator.Addition, level);
                break;
            case nameof(Operator.Subtraction):
                GenerateProblems(Operator.Subtraction, level);
                break;
            case nameof(Operator.Multiplication):
                GenerateProblems(Operator.Multiplication, level);
                break;
            case nameof(Operator.Division):
                GenerateProblems(Operator.Division, level);
                break;
            case "Random Game":
                GenerateProblems(null, level);
                break;
            default:
                throw new InvalidOperationException("Invalid operator");
        }
    }

    private static Operator GetRandomOperator()
    {
        var operators = new[] { Operator.Addition, Operator.Subtraction, Operator.Division, Operator.Multiplication };
        var randomIndex = RandomNumberGenerator.GenerateRandomNumber(0, operators.Length);
        return operators[randomIndex];
    }

    private void GenerateProblems(Operator? op, Level level)
    {
        Game game = new();
        int answer = 0;
        _stopwatch.Start();
        for (int i = 0; i < 10; i++)
        {
            bool isInteger = false;
            var problem = GenerateProblem(op ?? GetRandomOperator(), level);
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
            if (problem.IsCorrectAnswer())
            {
                game.Score++;
            }
        }
        _stopwatch.Stop();
        game.Time = _stopwatch.ElapsedMilliseconds / 1000;
        gameRepository.AddGame(game);
    }

    private static MathProblem GenerateProblem(Operator op, Level level)
    {
        var leftOperand = GetRandomNumber(level.LeftOperandDigit);
        var rightOperand = GetRandomNumber(level.RightOperandDigit);

        return op.Name switch
        {
            nameof(Operator.Addition) => new MathProblem(leftOperand, Operator.Addition.Symbol, rightOperand, leftOperand + rightOperand, null),
            nameof(Operator.Subtraction) => new MathProblem(leftOperand, Operator.Subtraction.Symbol, rightOperand, leftOperand - rightOperand, null),
            nameof(Operator.Multiplication) => new MathProblem(leftOperand, Operator.Multiplication.Symbol, rightOperand, leftOperand * rightOperand, null),
            nameof(Operator.Division) => GenerateDivisionProblem(leftOperand, rightOperand, level),
            _ => throw new InvalidOperationException("Unknown operator")
        };
    }

    private static int GetRandomNumber(int num)
    {
        return num switch
        {
            1 => RandomNumberGenerator.GenerateOneDigitRandomNumber(),
            2 => RandomNumberGenerator.GenerateTwoDigitRandomNumber(),
            3 => RandomNumberGenerator.GenerateThreeDigitRandomNumber(),
            _ => throw new InvalidOperationException("Invalid Number Of Digits")
        };
    }

    private static MathProblem GenerateDivisionProblem(int leftOperand, int rightOperand, Level level)
    {
        while (!(rightOperand != 0 && leftOperand % rightOperand == 0))
        {
            leftOperand = GetRandomNumber(level.LeftOperandDigit);
            rightOperand = GetRandomNumber(level.RightOperandDigit);
        }

        return new MathProblem(leftOperand, Operator.Division.Symbol, rightOperand, leftOperand / rightOperand, null);
    }
}