using Dapper;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using System.Data;

namespace Store.Infrastructure.Persistence.Repositories.QueriesRepositories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {

        private readonly IDbConnection _dbConnection;

        public CategoryQueryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            var sql = "SELECT * FROM Category WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Category>(sql, new { Id = categoryId });
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var sql = "SELECT * FROM Category";
            return await _dbConnection.QueryAsync<Category>(sql);
        }

    }
}
