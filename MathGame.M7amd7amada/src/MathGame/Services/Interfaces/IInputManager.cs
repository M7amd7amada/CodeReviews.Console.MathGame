namespace MathGame.Services.Interfaces;

public interface IInputManager
{
    Command TakeUserCommand();
    Level TakeUserLevel();
    Operator TakeUserOperator();
    (int answer, bool isInteger) TakeUserAnswer();
}