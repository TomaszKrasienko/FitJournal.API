using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitJournal.Domain.Entities;

public class Exercise
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool WithWieght { get; set; }
    public int UnitId { get; set; }
    [ForeignKey(nameof(UnitId))]
    public Unit Unit { get; set; }
}