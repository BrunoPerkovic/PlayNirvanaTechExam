using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PlayNirvanaTechExam.Interfaces.Repositories;

namespace PlayNirvanaTechExam.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext RepositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
        => RepositoryContext = repositoryContext;

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
            RepositoryContext.Set<T>()
                .AsNoTracking() :
            RepositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
        !trackChanges ?
            RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
            RepositoryContext.Set<T>()
                .Where(expression);

    public void Create(T entity) => RepositoryContext.Set<T>()
        .Add(entity);

    public void Update(T entity) => RepositoryContext.Set<T>()
        .Update(entity);

    public void Delete(T entity) => RepositoryContext.Set<T>()
        .Remove(entity);

    public void BulkCreate(IEnumerable<T> entities) => RepositoryContext.Set<T>()
        .AddRange(entities);

    public void BulkUpdate(IEnumerable<T> entities) => RepositoryContext.Set<T>()
        .UpdateRange(entities);

    public void BulkDelete(IEnumerable<T> entities) => RepositoryContext.Set<T>()
        .RemoveRange(entities);
}