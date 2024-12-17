using Lessons.Lesson_11_Module301_DataAccessLayer.Abstract;
using Lessons.Lesson_11_Module301_DataAccessLayer.Context;
using Lessons.Lesson_11_Module301_DataAccessLayer.Repositories;
using Lessons.Lesson_11_Module301_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_11_Module301_DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<object> GetProductsWithCategories()
        {
            BaseDbContext context = new BaseDbContext();
            var values = context.Products.Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                CategoryName = x.Category.Name
            }).ToList();

            return values.Cast<object>().ToList();
        }
    }
}
