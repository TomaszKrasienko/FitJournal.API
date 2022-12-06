using System.ComponentModel.DataAnnotations;
using FitJournal.Domain.Base;

namespace FitJournal.Domain.Models;

public class ExerciseType : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ExercisesTypeExercise> ExercisesList { get; set; }
}