namespace Model.ParticipantAnswer;

public class ParticipantAnswer
{
    public string ParticipantId { get; set; } = "";
    public string QuestionId { get; set; } = "";
    public int AnswerIndex { get; set; }
    public DateTime TimeStamp { get; set; }
}