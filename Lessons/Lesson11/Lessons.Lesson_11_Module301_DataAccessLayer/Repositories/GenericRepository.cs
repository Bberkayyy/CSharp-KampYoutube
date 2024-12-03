using Lessons.Lesson_11_Module301_DataAccessLayer.Abstract;
using Lessons.Lesson_11_Module301_DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_11_Module301_DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        BaseDbContext context = new BaseDbContext();
        private readonly DbSet<TEntity> _object;

        public GenericRepository()
        {
            _object = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return _object.ToList();
        }

        public TEntity GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(TEntity entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}