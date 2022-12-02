using FitJournal.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace FitJournal.Infrastructure.Data;

public class FitJournalDbContext : DbContext
{    
    public FitJournalDbContext(DbContextOptions<FitJournalDbContext> options) : base(options)
    {
        
    }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseType> ExercisesTypes { get; set; }
    public DbSet<ExercisesTypeExercise> ExercisesTypeExercises { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<TrainingUnit> TrainingsUnits { get; set; }
    public DbSet<ExerciseTrainingUnit> ExercisesTrainingUnits { get; set; }
    
}