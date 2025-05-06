using CaishenManagementAPI.Entity;

namespace CaishenManagementAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

    }
}
