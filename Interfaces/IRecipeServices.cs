using FoodRecipesApp.Models;

namespace FoodRecipesApp.Interfaces
{
    public interface IRecipeServices
    {
        Task<int> AddAsync(Recipe recipe);
        Task<int> UpdateAsync(Recipe recipe);
        Task<int> DeleteAsync(Recipe recipe);
        Task<List<Recipe>> GetAllAsync();
        Task<Recipe> GetAsync(int id);
        Task<List<Recipe>> GetAllByOriginIdAsync(int originId);

    }
}
