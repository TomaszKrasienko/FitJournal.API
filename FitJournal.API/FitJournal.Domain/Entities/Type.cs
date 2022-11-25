using System.ComponentModel.DataAnnotations;

namespace FitJournal.Domain.Entities;

public class Type
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}