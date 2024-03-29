namespace RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;

public interface IAsyncRepository<T> where T 
    : class
{
    Task<bool> IsExist(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}