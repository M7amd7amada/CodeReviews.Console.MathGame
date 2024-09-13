namespace MathGame.Services.Interfaces;

public interface ICommandHandler
{
    void Handle(Command command);
}