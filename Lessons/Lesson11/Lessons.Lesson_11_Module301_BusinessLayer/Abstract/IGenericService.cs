using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_11_Module301_BusinessLayer.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        void TInsert(TEntity entity);
        void TUpdate(TEntity entity);
        void TDelete(TEntity entity);
        List<TEntity> TGetAll();
        TEntity TGetById(int id);
    }
}
