namespace MathGame.Models;

public class MathProblem(int leftOperand, int op, int rightOperand, int answer, int? userAnswer)
{
    public int LeftOperand { get; set; } = leftOperand;
    public int Operator { get; set; } = op;
    public int RightOperand { get; set; } = rightOperand;
    public int Answer { get; set; } = answer;
    public int? UserAnswer { get; set; } = userAnswer;
    public bool IsCorrectAnswer() => Answer == UserAnswer;
}