using EFCore.BulkExtensions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Cig.Cdu.Infrastructure.Repositories
{
    public class Repository<T> where T : class
    {
        protected DbSet<T> _dbSet;

        protected AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        // Retorna null se não encontrado
        public T GetById(Guid Id)
        {
            _dbContext.ChangeTracker.Clear();
            var entity = _dbSet.Find(Id);

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public DbSet<T> GetInstance => _dbSet;

        public IEnumerable<T> GetAll()
        {
            _dbContext.ChangeTracker.Clear();
            return _dbSet.ToList();
        }

        public int Create(T entity)
        {
            if (entity is not null)
                _dbContext.Entry(entity).State = EntityState.Added;

            _dbSet.Add(entity);
            return _dbContext.SaveChanges();
        }

        public T CreateScope(T entity)
        {
            _dbSet.Add(entity);

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }

            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<int> CreateRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (entity is not null)
                        _dbContext.Entry(entity).State = EntityState.Added;
                }

                _dbSet.AddRange(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex", ex.Message);
                throw;
            }

        }

        public int CreateRange(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (entity is not null)
                        _dbContext.Entry(entity).State = EntityState.Added;
                }

                _dbSet.AddRange(entities);
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex", ex.Message);
                throw;
            }

        }

        public async Task<int> CreateRangeAsyncNoTracking(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);

            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity is not null)
            {
                // Define CreatedAt e UpdatedAt com a data atual
                var now = DateTime.UtcNow;
                var type = typeof(T);
                var createdAtProperty = type.GetProperty("UpdatedDate");
                var updatedAtProperty = type.GetProperty("CreatedDate");

                if (createdAtProperty != null)
                    createdAtProperty.SetValue(entity, now, null);

                if (updatedAtProperty != null)
                    updatedAtProperty.SetValue(entity, now, null);

                _dbContext.Entry(entity).State = EntityState.Added;
            }

            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> prPredicate)
        {
            IEnumerable<T> result = new List<T>();

            var linq = _dbSet
                .Where(prPredicate)
                .AsQueryable();

            result = linq.ToList();

            return result;
        }

        public IEnumerable<T> GetAllRaw(string rawSql)
        {
            IEnumerable<T> result = new List<T>();

            result = _dbSet.FromSqlRaw(rawSql).ToList();

            return result;
        }

        public T Get(Expression<Func<T, bool>> prPredicate)
        {
            _dbContext.ChangeTracker.Clear();

            var linq = _dbSet
                .Where(prPredicate)
                .AsQueryable();

            T result = linq.FirstOrDefault();

            if (result != null)
                _dbContext.Entry(result).State = EntityState.Detached;

            return result;
        }

        public T GetAsNoTracking(Expression<Func<T, bool>> prPredicate)
        {
            _dbContext.ChangeTracker.Clear();

            var linq = _dbSet
                .Where(prPredicate)
                .AsNoTracking()
                .AsQueryable();

            T result = linq.FirstOrDefault();

            if (result != null)
                _dbContext.Entry(result).State = EntityState.Detached;

            return result;
        }

        public T Update(T entity)
        {

            var type = entity.GetType().Name;

            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public ICollection<T> UpdateRange(ICollection<T> entities)
        {
            _dbContext.ChangeTracker.Clear();

            foreach (var entity in entities.ToList())
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            _dbSet.UpdateRange(entities);
            _dbContext.SaveChanges();
            return entities;
        }

        public void UpdateBulkRange(Expression<Func<T, bool>> prPredicateWhere, T entity)
        {
            _dbSet.Where(prPredicateWhere).BatchUpdate<T>(entity);
            _dbContext.BulkSaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public int DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return _dbContext.SaveChanges();
        }

        public int Delete(Expression<Func<T, bool>> prPredicate)
        {
            var entityRange = _dbSet
                .Where(prPredicate)
                .AsEnumerable();

            _dbSet.RemoveRange(entityRange);
            return _dbContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            var entitiesList = entities.ToList();

            foreach (var entity in entitiesList)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            _dbContext.UpdateRange(entitiesList);
            _dbContext.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public List<T> CreateRangeEntities(List<T> entities)
        {
            _dbSet.AddRange(entities);
            _dbContext.SaveChanges();

            return entities;
        }

        public bool AddOrUpdateRange(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (!_dbSet.Any(e => e == entity))
                    {
                        _dbSet.Add(entity);
                    }
                    else
                    {
                        _dbSet.Update(entity);
                    }

                    _dbContext.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                var aux = ex.Message;

                return false;
            }
        }
    }
}