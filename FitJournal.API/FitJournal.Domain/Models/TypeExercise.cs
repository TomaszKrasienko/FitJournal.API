using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitJournal.Domain.Base;

namespace FitJournal.Domain.Models;
public class ExercisesTypeExercise : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public int ExerciseTypeId { get; set; }
    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }
    [ForeignKey(nameof(ExerciseTypeId))] 
    public ExerciseType? ExerciseType { get; set; }
}