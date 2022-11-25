using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitJournal.Domain.Entities;

public class TypeExercise
{
    [Key]
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public int TypeId { get; set; }
    [ForeignKey(nameof(ExerciseId))]
    public Exercise Exercise { get; set; }
    [ForeignKey(nameof(TypeId))] 
    public Type Type { get; set; }
}