using System.ComponentModel.DataAnnotations;

namespace FitJournal.Domain.Entities;

public class ExerciseTreningUnit
{
    [Key]
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public int TreningUnitId { get; set; }
    public double Quantity { get; set; }
    public double? Weight { get; set; }
}