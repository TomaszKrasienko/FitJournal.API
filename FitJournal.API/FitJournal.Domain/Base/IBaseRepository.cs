using FitJournal.Domain.Wrappers;

namespace FitJournal.Domain.Base;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(PaginationParameters parameters);
    Task<T> AddAsync(T entity);
}