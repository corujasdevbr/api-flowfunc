using Corujasdev.Flowfunc.Application.Repositories;
using Corujasdev.Flowfunc.Domain.Common;
using Corujasdev.Flowfunc.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Corujasdev.Flowfunc.Persistence.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        entity.DateCreated = DateTime.UtcNow;
        _context.Add(entity);
    }
    public void Remove(T entity)
    {
        entity.DateDeleted = DateTime.UtcNow;
        _context.Update(entity);
    }

    public T Update(T entity)
    {
        entity.DateUpdated = DateTime.UtcNow;
        _context.Update(entity);
        return entity;
    }

    public IEnumerable<T>? GetAll(string[]? includes = null)
    {
        var query = _context.Set<T>().AsNoTracking();

        if (includes == null) return query;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }

    public async Task<T?> GetById(Guid id, CancellationToken cancellationToken, string[] ? includes = null )
    {
        var query = _context.Set<T>().AsNoTracking();

        if (includes == null) return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IEnumerable<T>? Find(Func<T, bool> expr, string[]? includes = null)
    {
        var query = _context.Set<T>().AsNoTracking();

        if (includes == null) return query.Where(expr);

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query.Where(expr);
    }
}