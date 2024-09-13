namespace MathGame.Services.Interfaces;

public interface IInputManager
{
    Command TakeUserCommand();
    Operator TakeUserOperator();
    (int answer, bool isInteger) TakeUserAnswer();
}