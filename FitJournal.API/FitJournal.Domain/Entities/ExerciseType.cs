using System.ComponentModel.DataAnnotations;

namespace FitJournal.Domain.Entities;

public class ExerciseType
{
    [Key]
    public int Id { get; set; }
    public int TypeId { get; set; }
    public int ExerciseId { get; set; }
}