namespace Model.Question;

using Model.ParticipantAnswer;
public class Question
{
    public string Id { get; set; }
    public string Text { get; set; } = "";
    public List<string> Answers { get; set; }
    public int CorrectAnswer { get; set; }
    public List<ParticipantAnswer> participantAnswers { get; set; }
    public List<int> VoteCount { get; set; }
}