using System.Linq.Expressions;

namespace PlayNirvanaTechExam.Interfaces.Repositories;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    void BulkCreate(IEnumerable<T> entities);
    void BulkUpdate(IEnumerable<T> entities);
    void BulkDelete(IEnumerable<T> entities);
}