using AzureWebApp.Models;

namespace AzureWebApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Task<bool> IsBetaAsync();
    }
}