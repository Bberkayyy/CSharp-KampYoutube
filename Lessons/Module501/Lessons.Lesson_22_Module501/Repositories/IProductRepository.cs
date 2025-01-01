using Lessons.Lesson_22_Module501.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_22_Module501.Repositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(int id);
        Task<ResultProductDto> GetByIdAsync(int id);
    }
}
