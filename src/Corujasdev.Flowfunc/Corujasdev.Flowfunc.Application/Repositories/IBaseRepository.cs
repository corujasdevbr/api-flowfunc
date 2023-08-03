using Corujasdev.Flowfunc.Domain.Common;

namespace Corujasdev.Flowfunc.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Add(T entity);
    T Update(T entity);
    void Remove(T entity);
    Task<T?> GetById(Guid id, CancellationToken cancellationToken, string[]? includes = null);
    IEnumerable<T>? Find(Func<T, bool> expr, string[]? includes = null);
    IEnumerable<T>? GetAll(string[]? includes = null);
}