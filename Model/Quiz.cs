namespace Model.Quiz; 
using Model.Question; 

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public List<Question> Questions { get; set; }
    public int CurrentQuestionIndex { get; set; }
}