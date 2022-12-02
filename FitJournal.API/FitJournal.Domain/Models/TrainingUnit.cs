using System.ComponentModel.DataAnnotations;
using FitJournal.Domain.Base;

namespace FitJournal.Domain.Models;

public class TrainingUnit : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public List<ExerciseTrainingUnit>? ExerciseTrainingUnitsList { get; set; }
}