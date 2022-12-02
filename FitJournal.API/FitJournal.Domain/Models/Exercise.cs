using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitJournal.Domain.Base;

namespace FitJournal.Domain.Models;

public class Exercise : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool WithWeight { get; set; }
    public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))]
    public Unit? Unit { get; set; }
    public List<ExerciseTrainingUnit>? ExerciseTrainingUnitsList { get; set; }
}