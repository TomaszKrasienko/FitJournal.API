using FitJournal.Domain.Base;

namespace FitJournal.Domain.Entity;

public class WithWeight : ValueObject<WithWeight>
{
    public bool IsWithWeight { get; }
    public WithWeight(bool isWithWeight)
    {
        IsWithWeight = isWithWeight;
    }
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    {
        yield return IsWithWeight; 
    }
}