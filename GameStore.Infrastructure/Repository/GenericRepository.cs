using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GameStore.Core.Interfaces;
using GameStore.Infrastructure.Data;

namespace GameStore.Infrastructure.Repository
{
    class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private GameStoreDbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(GameStoreDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public TEntity FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate).ToList();
            }

            return _dbSet.ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

//        public void Update(TEntity changes, TEntity toEdit)
//        {
//            Clone(ref toEdit,changes);
//            _context.Entry(toEdit).State = EntityState.Modified;
//        }

        private void Clone(ref TEntity to, TEntity from)
        {
            foreach (var prop in typeof(TEntity).GetProperties())
            {
                if (prop.CanRead)
                {
                    var val = prop.GetValue(from, null);
                    prop.SetValue(to, val);
                }
            }
        }
    }
}
