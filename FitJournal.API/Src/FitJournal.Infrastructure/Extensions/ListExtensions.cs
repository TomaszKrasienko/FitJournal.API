using FitJournal.Domain.Base;

namespace FitJournal.Infrastructure.Extensions;

public static class ListExtensions
{
    public static bool IsNullOrEmpty(this List<IEntityBase> list)
    {
        if (list is null)
            return false;
        return list.Any();
    }
}