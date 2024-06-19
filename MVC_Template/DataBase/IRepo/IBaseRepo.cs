using MVC_Template.DataBase.Entity;
using MVC_Template.Models;

namespace MVC_Template.DataBase.IRepo
{
    public interface IBaseRepo
    {
        ServiceResult<TEntity> GetEntityById<TEntity>(int id) where TEntity : BaseEntity;
        ServiceResult<List<TEntity>> GetAllEntitys<TEntity>() where TEntity : class;
        bool AddUpdateEntity<TEntity>(TEntity entity) where TEntity : BaseEntity;
        bool RemoveEntityByInstance<TEntity>(TEntity entity) where TEntity : class;
        bool RemoveEntityById<TEntity>(int id) where TEntity : BaseEntity;
    }
}
