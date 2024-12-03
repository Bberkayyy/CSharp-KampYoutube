using Lessons.Lesson_11_Module301_DataAccessLayer.Abstract;
using Lessons.Lesson_11_Module301_DataAccessLayer.Repositories;
using Lessons.Lesson_11_Module301_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_11_Module301_DataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
    }
}
