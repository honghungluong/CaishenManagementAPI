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

        public async Task<Product?> GetById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task Add(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

    }
}
