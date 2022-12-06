using System.ComponentModel.DataAnnotations;

namespace FitJournal.API.DTOs.Exercises;

public class ExerciseDto
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public bool WithWeight { get; set; }
    [Required]
    public int? UnitId { get; set; }
}