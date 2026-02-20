using System.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Model.ParticipantAnswer;
using Model.Question;
using Model.Quiz;

public class QuizManager
{
    Dictionary<string, Quizz> quizzes = [];

    public event Action? OnStateChanged;

    public QuizManager()
    {
        Quizz quizz = new Quizz()
        {
            Id = "1",
            Title = "Enkät v8",
            Questions = new List<Question>
            {
                new Question
                {
                    Id = "1",
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
        // quizzes.Add(quizz.Id, quizz);
        quizzes[quizz.Id] = quizz;
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

    public void SubmitAnswer(string participantId, int answerIndex, Question question)
    {
        // quizzes[questionId].Questions[quizzes[questionId].CurrentQuestionIndex].participantAnswers.Add(new ParticipantAnswer() { ParticipantId = participantId, AnswerIndex = answerIndex });
        if (!quizzes.TryGetValue(quizId, out var quizz))
        {
            return;
        }
        if (quizz.Questions.Count == 0)
        {
            return;
        }
        var question = quizz.Questions[quizz.CurrentQuestionIndex];

        var answer = new ParticipantAnswer
        {
            ParticipantId = participantId,
            QuestionId = question.Id,
            AnswerIndex = answerIndex,
            TimeStamp = DateTime.UtcNow
        };

        question.participantAnswers.Add(answer);
        Console.WriteLine("Answer added!");

        var last = question.participantAnswers.LastOrDefault();
        if (last != null)
        {
            Console.WriteLine(last.AnswerIndex);
        }
        OnStateChanged?.Invoke();
    }
    // public void SubmitAnswer(string participantId, int answerIndex, string questionId)
    // {
    //     quizzes[questionId].Questions[quizzes[questionId].CurrentQuestionIndex].participantAnswers.Add(new ParticipantAnswer() { ParticipantId = participantId, AnswerIndex = answerIndex });

    //     Console.WriteLine("XXXXXXXXXXXXxxxxXXXXXXXXXXXXXXXXXx");
    //     Console.WriteLine(quizzes[questionId].Questions[quizzes[questionId].CurrentQuestionIndex].participantAnswers.LastOrDefault().AnswerIndex);
    // }
    public void NextQuestion()
    {

    }
}