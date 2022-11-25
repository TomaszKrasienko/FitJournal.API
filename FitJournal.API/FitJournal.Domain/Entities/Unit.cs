using System.ComponentModel.DataAnnotations;

namespace FitJournal.Domain.Entities;

public class Unit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Shortcut { get; set; }

    public List<Exercise> ExercisesList { get; set; }
}