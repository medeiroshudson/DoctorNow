using System.Linq.Expressions;

namespace DoctorNow.Domain.SharedKernel.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> Get();
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsUnique(Expression<Func<TEntity, bool>> condition);
}