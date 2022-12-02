using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitJournal.Domain.Base;

namespace FitJournal.Domain.Models;
public class ExerciseTrainingUnit : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public int? ExerciseId { get; set; }
    public int TrainingUnitId { get; set; }
    public double? Quantity { get; set; }
    public double? Weight { get; set; }
    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise  { get; set; }
    [ForeignKey(nameof(TrainingUnitId))]
    public TrainingUnit? TrainingUnit { get; set; }
}