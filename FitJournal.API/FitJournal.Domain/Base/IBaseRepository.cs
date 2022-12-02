namespace FitJournal.Domain.Base;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
}