using Model.ParticipantAnswer;
using Model.Question;
using Model.Quiz;

public class QuizManager
{
    Dictionary<string, Quizz> quizzes;
    Quizz quizz = new Quizz()
    {
        Id = 1,
        Title = "Enkät v8",
        Questions = new List<Question>
        {
            new Question
            {
                Id = 1,
                Text = "Vilket djur är känt för att vara världens snabbaste på land?",
                Answers = new List<string>
                {
                    "Lejon",
                    "Gepard",
                    "Antilop",
                    "Struts"
                },
                CorrectAnswer = 1, // Index 1 = "Gepard"
                participantAnswers = new List<ParticipantAnswer>
                {
                    new ParticipantAnswer { ParticipantId = "1", AnswerIndex = 1, TimeStamp = DateTime.Now },
                    new ParticipantAnswer { ParticipantId = "2", AnswerIndex = 3, TimeStamp = DateTime.Now },
                    new ParticipantAnswer { ParticipantId = "3", AnswerIndex = 1, TimeStamp = DateTime.Now }
                },
                VoteCount = new List<int> { 0, 2, 0, 1 }
            },
        },
        CurrentQuestionIndex = 0
    };
    public Quizz GetQuiz()
    {
        return quizz;
    }
    public void SubmitAnswer()
    {

    }
    public void NextQuestion()
    {

    }
}