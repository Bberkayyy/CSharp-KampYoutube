using Dapper;
using Lessons.Lesson_22_Module501.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lessons.Lesson_22_Module501.Repositories
{
    public class ProductRepository : IProductRepository
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EgitimKampiDapperDb;Integrated Security=True;");

        public async Task CreateAsync(CreateProductDto createProductDto)
        {
            string query = "insert into TblProduct (Name,Stock,Price,CategoryName) values (@name,@stock,@price,@categoryName)";
            await connection.ExecuteAsync(query, createProductDto);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from TblProduct where Id = @id";
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            string query = "select * from TblProduct";
            IEnumerable<ResultProductDto> values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }

        public async Task<ResultProductDto> GetByIdAsync(int id)
        {
            string query = "select * from TblProduct where Id = @id";
            return await connection.QueryFirstOrDefaultAsync<ResultProductDto>(query, new { Id = id });
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            string query = " update TblProduct set Name = @name, Price = @price, Stock = @stock, CategoryName = @categoryName where Id = @id";
            await connection.ExecuteAsync(query, updateProductDto);
        }
    }
}
