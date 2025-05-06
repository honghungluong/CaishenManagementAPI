using CaishenManagementAPI.Datacontext;
using CaishenManagementAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace CaishenManagementAPI.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly CaishenMngtDbContext _dbContext;

        public ProductRepository(CaishenMngtDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
