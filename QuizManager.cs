using System.Text.Json;
using Model.ParticipantAnswer;
using Model.Question;
using Model.Quiz;

public class QuizManager
{
    Dictionary<string, Quizz> quizzes = [];

    public event Action? OnStateChanged;

    public QuizManager()
    {
        string? quizzPath = Path.Combine(AppContext.BaseDirectory, "Data", "quizzes.json");

        if (!File.Exists(quizzPath))
            return;

        string? json = File.ReadAllText(quizzPath);

        var loaded = JsonSerializer.Deserialize<List<Quizz>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (loaded == null)
            return;

        foreach (Quizz quiz in loaded)
        {
            foreach (Question q in quiz.Questions)
            {
                q.participantAnswers = new();
                q.VoteCount = Enumerable.Repeat(0, q.Answers.Count).ToList();
            }
            quizzes[quiz.Id] = quiz;
        }
        // Quizz quizz = new Quizz()
        // {
        //     Id = "1",
        //     Title = "Enkät v8",
        //     Questions = new List<Question>
        //     {
        //         new Question
        //         {
        //             Id = "1",
        //             Text = "Vilket djur är känt för att vara världens snabbaste på land?",
        //             Answers = new List<string>
        //             {
        //                 "Lejon",
        //                 "Gepard",
        //                 "Antilop",
        //                 "Struts"
        //             },
        //             CorrectAnswer = 1, // Index 1 = "Gepard"
        //             participantAnswers = new List<ParticipantAnswer>
        //             {
        //                 new ParticipantAnswer { ParticipantId = "1", AnswerIndex = 1, TimeStamp = DateTime.Now },
        //                 new ParticipantAnswer { ParticipantId = "2", AnswerIndex = 3, TimeStamp = DateTime.Now },
        //                 new ParticipantAnswer { ParticipantId = "3", AnswerIndex = 1, TimeStamp = DateTime.Now }
        //             },
        //             VoteCount = new List<int> { 0, 2, 0, 1 }
        //         },
        //     },
        //     CurrentQuestionIndex = 0

        // };
        // quizzes[quizz.Id] = quizz;
    }

    public Quizz? GetQuizById(string id)
    {
        if (quizzes.TryGetValue(id, out Quizz? value))
        {
            return value;
        }
        else
        {
            return null;
        }
    }

    public void SubmitAnswer(string participantId, int answerIndex, string quizId)
    {
        if (!quizzes.TryGetValue(quizId, out var quiz))
            return;
        if (quiz.Questions.Count == 0)
            return;
        var question = quiz.Questions[quiz.CurrentQuestionIndex];
        bool alreadyAnswered = question.participantAnswers.Any(a => a.ParticipantId == participantId);
        if (alreadyAnswered)
            return;
        var answer = new ParticipantAnswer
        {
            ParticipantId = participantId,
            QuestionId = question.Id,
            AnswerIndex = answerIndex,
            TimeStamp = DateTime.UtcNow
        };
        question.participantAnswers.Add(answer);
        question.VoteCount[answerIndex]++;
        OnStateChanged?.Invoke();
    }
    public bool CheckCorrectAnswer(string quizId, int answerIndex)
    {
        if (!quizzes.TryGetValue(quizId, out var quiz))
            return false;
        var question = quiz.Questions[quiz.CurrentQuestionIndex];

        bool isCorrect = question.CorrectAnswer == answerIndex;

        return isCorrect;
    }
    public void NextQuestion(string quizId)
    {
        if (!quizzes.TryGetValue(quizId, out var quiz))
            return;
        if (quiz.CurrentQuestionIndex < quiz.Questions.Count - 1)
            quiz.CurrentQuestionIndex++;
        OnStateChanged?.Invoke();
    }
}