using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Models;

namespace FoodRecipesApp.Services
{
    public class RecipeServices : IRecipeServices
    {
        public Task<int> AddAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetAllByOriginIdAsync(int originId)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
