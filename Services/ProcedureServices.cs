using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Models;

namespace FoodRecipesApp.Services
{
    public class ProcedureServices : IProcedureServices
    {
        public Task<int> AddAsync(Procedure procedure)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Procedure procedure)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetAllByRecipeIdAsync(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Procedure procedure)
        {
            throw new NotImplementedException();
        }
    }
}
