using Microsoft.EntityFrameworkCore;
using Model.ParticipantAnswer;
using Model.Question;
using Model.Quiz;

public class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options)
{
    public DbSet<Quizz> Quizzes => Set<Quizz>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<ParticipantAnswer> Answers => Set<ParticipantAnswer>();
}