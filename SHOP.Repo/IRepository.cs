using System.Collections.Generic;

namespace SHOP.Repo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> getAll();
        TEntity getDataById(int id);
        void addEntity(TEntity obj);
        void updateEntity(TEntity obj);
        void removeEntity(int id);
    }
}
