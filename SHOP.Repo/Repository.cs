using System.Collections.Generic;
using System.Linq;
using SHOP.DL;
namespace SHOP.Repo
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ShopEntity dbContex;
        public Repository(ShopEntity _dbcontext)
        {
            dbContex = _dbcontext;
        }
        public void addEntity(TEntity obj)
        {
            dbContex.Set<TEntity>().Add(obj);
            
        }
        public IEnumerable<TEntity> getAll()
        {
            return dbContex.Set<TEntity>().ToList();
        }
        public TEntity getDataById(int id)
        {
            return dbContex.Set<TEntity>().Find(id);
        }
        public void removeEntity(int id)
        {
            dbContex.Set<TEntity>().Remove(dbContex.Set<TEntity>().Find(id));

        }
        public void updateEntity(TEntity obj)
        { /*
           DbSet.Attach(entity);
     var entry = Context.Entry(entity);
     entry.State = System.Data.EntityState.Modified;
           */
            dbContex.Set<TEntity>().Attach(obj);
            var entry = dbContex.Entry(obj);
            entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
