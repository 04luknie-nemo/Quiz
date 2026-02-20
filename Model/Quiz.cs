namespace Model.Quiz;

using Model.Question;

public class Quizz
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public List<Question> Questions { get; set; }
    public int CurrentQuestionIndex { get; set; }
}