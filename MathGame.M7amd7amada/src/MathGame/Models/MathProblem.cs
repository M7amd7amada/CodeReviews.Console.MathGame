namespace MathGame.Models;

public class MathProblem
{
    public MathProblem(int leftOperand, int @operator, int rightOperand, int answer, int? userAnswer)
    {
        LeftOperand = leftOperand;
        Operator = @operator;
        RightOperand = rightOperand;
        Answer = answer;
        UserAnswer = userAnswer;
    }

    public int LeftOperand { get; set; }
    public int Operator { get; set; }
    public int RightOperand { get; set; }
    public int Answer { get; set; }
    public int? UserAnswer { get; set; }
    public bool IsCorrectAnswer() => Answer == UserAnswer;
}