using MathGame.Models;
using MathGame.Helpers;

namespace MathGame.Services;

public class OperatorHandler(IDisplayManager displayManager, IInputManager inputManager) : IOperatorHandler
{
    public void Handle(Operator op)
    {
        switch (op.Name)
        {
            case nameof(Operator.Addition):
                GenerateProblems();
                break;
            case nameof(Operator.Subtraction):
                break;
            case nameof(Operator.Multiplication):
                break;
            case nameof(Operator.Division):
                break;
            case nameof(Operator.Random):
                break;
        };
    }

    private void GenerateProblems()
    {
        Game game = new();
        int answer = 0;
        var watch = new System.Diagnostics.Stopwatch();

        watch.Start();
        for (int i = 0; i < 10; i++)
        {
            bool isInteger = false;
            var problem = GenerateAdditionProblem();
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
        watch.Stop();
        game.Time = watch.ElapsedMilliseconds / 1000;
        Console.WriteLine("Score " + game.Score);
    }

    private static MathProblem GenerateAdditionProblem()
    {
        var leftOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
        var rightOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
        return new MathProblem(leftOperand, Operator.Addition.Symbol, rightOperand, leftOperand + rightOperand, null);
    }

    private static MathProblem GenerateSubtractionProblem()
    {
        var leftOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
        var rightOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
        return new MathProblem(leftOperand, Operator.Subtraction.Symbol, rightOperand, leftOperand - rightOperand, null);
    }

    private static MathProblem GenerateMultiplicationProblem()
    {
        var leftOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
        var rightOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
        return new MathProblem(leftOperand, Operator.Multiplication.Symbol, rightOperand, leftOperand * rightOperand, null);
    }
    private static MathProblem GenerateDivisionProblem()
    {
        // Choose Dumy Values To Make Them Pass the While Condition
        int leftOperand = -1, rightOperand = -2;

        while (leftOperand % rightOperand != 0)
        {
            leftOperand = RandomNumberGenerator.GenerateRandomNumber(0, 9);
            rightOperand = RandomNumberGenerator.GenerateRandomNumber(1, 9);
        }

        return new MathProblem(leftOperand, Operator.Division.Symbol, rightOperand, leftOperand / rightOperand, null);
    }
}