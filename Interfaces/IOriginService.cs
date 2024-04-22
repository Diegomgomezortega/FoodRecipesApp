using FoodRecipesApp.Models;

namespace FoodRecipesApp.Interfaces
{
    public interface IOriginService
    {
        Task<int> AddAsync(Origin origin);
        Task<int> UpdateAsync(Origin origin);
        Task<int> DeleteAsync(Origin origin);
        Task<List<Origin>> GetAllAsync();
    }
}
