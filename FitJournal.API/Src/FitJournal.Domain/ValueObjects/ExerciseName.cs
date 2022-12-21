using FitJournal.Domain.Base;
using FitJournal.Domain.Entity;

namespace FitJournal.Domain.ValueObjects;

public class ExerciseName : ValueObject<ExerciseName>
{
    public string ShortName { get; }
    public string LongName { get; }
    protected ExerciseName() { }
    public ExerciseName(string shortName, string longName)
    {
        if (string.IsNullOrWhiteSpace(shortName))
            throw new ArgumentException("First name cannot be empty");
        ShortName = shortName;
        LongName = longName;
    }
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return ShortName;
        yield return LongName;
    }
}