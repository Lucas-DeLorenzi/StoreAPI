using Dapper;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using System.Data;

namespace Store.Infrastructure.Persistence.Repositories.QueriesRepositories
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductQueryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            var sql = "SELECT * FROM Product WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = productId });
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Product";
            return await _dbConnection.QueryAsync<Product>(sql);
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
            var sql = "SELECT * FROM Product WHERE CategoryId = @CategoryId";
            return await _dbConnection.QueryAsync<Product>(sql, new { CategoryId = categoryId });
        }
    }
}
