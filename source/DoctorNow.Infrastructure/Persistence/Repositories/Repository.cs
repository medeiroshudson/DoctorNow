using Microsoft.EntityFrameworkCore;
using DoctorNow.Domain.SharedKernel;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Infrastructure.Persistence.Contexts;

namespace DoctorNow.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _dbContext;

    protected Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IQueryable<TEntity> Get() => _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();

    public async Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await Get().ToListAsync(cancellationToken);
    
    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    
    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbContext.Set<TEntity>().AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == entity.Id, cancellationToken);
        
        if (existingEntity is not null)
            _dbContext.Set<TEntity>().Update(entity);
    }
    
    public async Task UpsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entry = _dbContext.Entry(entity);

        if (entry.State == EntityState.Detached) await AddAsync(entity, cancellationToken);
        else entry.State = EntityState.Modified;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        
        if (entity is not null)
            _dbContext.Set<TEntity>().Remove(entity);
    }
}