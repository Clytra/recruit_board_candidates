using Microsoft.EntityFrameworkCore;
using RecruitBoard.Services.Candidates.Application.Contracts.Infrastructure;

namespace RecruitBoard.Services.Candidates.Infrastructure.Repositories;

public class BaseRepository<T>(DataContext context) : IAsyncRepository<T>
    where T : class
{
    protected readonly DataContext _context = context;

    public virtual async Task<bool> IsExist(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity != null;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        var t = await _context.Set<T>().FindAsync(id);
        return t;
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
        => await _context.Set<T>().ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}