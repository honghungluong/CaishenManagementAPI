using CaishenManagementAPI.Models;

namespace CaishenManagementAPI.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

    }
}
