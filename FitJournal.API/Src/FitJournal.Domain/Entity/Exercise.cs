using FitJournal.Domain.Base;
using FitJournal.Domain.ValueObjects;

namespace FitJournal.Domain.Entity;

public class Exercise : BaseEntity
{
    public int Id { get; init; }
    public ExerciseName Name { get; init; }
    public WithWeight WithWeight { get; init; }

    public Exercise(int id, ExerciseName name, WithWeight withWeight) : base()
    {
        Id = id;
        Name = name;
        WithWeight = withWeight;
    }
}