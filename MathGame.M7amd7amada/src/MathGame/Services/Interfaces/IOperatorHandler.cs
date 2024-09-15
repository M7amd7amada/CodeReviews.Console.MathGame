namespace MathGame.Services.Interfaces;

public interface IOperatorHandler
{
    void Handle(Operator op, Level level);
}