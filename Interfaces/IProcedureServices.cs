using FoodRecipesApp.Models;

namespace FoodRecipesApp.Interfaces
{
    public interface IProcedureServices
    {
        Task<int> AddAsync(Procedure procedure);
        Task<int> UpdateAsync(Procedure procedure);
        Task<int> DeleteAsync(Procedure procedure);
        Task<List<Recipe>> GetAllAsync();
        Task<Recipe> GetAsync(int id);
        Task<List<Recipe>> GetAllByRecipeIdAsync(int recipeId);
    }
}
