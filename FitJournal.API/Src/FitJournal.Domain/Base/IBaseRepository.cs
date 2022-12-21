using FitJournal.Domain.Wrappers;

namespace FitJournal.Domain.Base;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(PaginationParameters parameters);
    Task<T> AddAsync(T entity);
    Task<T> EditAsync(int id, T entity);
    Task<int> DeleteAsync(int id);
}