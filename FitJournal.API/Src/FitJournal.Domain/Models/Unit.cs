using System.ComponentModel.DataAnnotations;
using FitJournal.Domain.Base;

namespace FitJournal.Domain.Models;

public class Unit : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Shortcut { get; set; }
    public List<Exercise>? ExercisesList { get; set; }
}