using MVC_Template.DataBase.Entity;
using MVC_Template.DataBase.IRepo;
using MVC_Template.Models;

namespace MVC_Template.DataBase
{
    public class BaseRepo : IBaseRepo
    {
        private readonly AppDbContext _dbContext;
        public BaseRepo(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }


        public ServiceResult<TEntity> GetEntityById<TEntity>(int id) where TEntity : BaseEntity
        {
            try
            {
                var dbSet = _dbContext.Set<TEntity>();

                var res = dbSet.FirstOrDefault(x => x.Id == id);
                if (res == null)
                {
                    return new();
                }
                return new()
                {
                    IsSuccess = true,
                    Result = res
                };
            }
            catch (Exception ex)
            {
                return new();
            }
        }
        public ServiceResult<List<TEntity>> GetAllEntitys<TEntity>() where TEntity : class
        {
            try
            {
                var dbSet = _dbContext.Set<TEntity>();

                var res = dbSet.ToList();
                return new()
                {
                    IsSuccess = true,
                    Result = res
                };
            }
            catch (Exception ex)
            {
                return new();
            }
        }
        public bool AddUpdateEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            try
            {
                var dbSet = _dbContext.Set<TEntity>();
                if (entity.Id == 0)
                {
                    dbSet.Add(entity);
                }
                else
                {
                    dbSet.Update(entity);
                }
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RemoveEntityByInstance<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                var dbSet = _dbContext.Set<TEntity>();

                dbSet.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RemoveEntityById<TEntity>(int id) where TEntity : BaseEntity
        {
            try
            {
                var dbSet = _dbContext.Set<TEntity>();

                var entity = dbSet.FirstOrDefault(x => x.Id == id);
                if (entity == null)
                {
                    return false;
                }
                dbSet.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
