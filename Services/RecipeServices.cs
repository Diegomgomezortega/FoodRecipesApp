using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Models;
using SQLiteNetExtensionsAsync.Extensions;

namespace FoodRecipesApp.Services
{
    public class RecipeServices :BaseServices, IRecipeServices
    {
        public async Task<int> AddAsync(Recipe recipe)
        {
            if (recipe is null)
                return (int)System.Net.HttpStatusCode.BadRequest;
            int result = await connection.InsertAsync(recipe);
            return result;
        }

        public async Task<int> DeleteAsync(Recipe recipe)
        {
            var result = await connection?.DeleteAsync(recipe);
            return result;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            var result = await connection.GetAllWithChildrenAsync<Recipe>(recursive:true);
            if (result.Count == 0) return null;
            return result.ToList();
        }

        public async Task<List<Recipe>> GetAllByOriginIdAsync(int originId)
        {
            var result = await connection.GetAllWithChildrenAsync<Recipe>(x => x.OriginId == originId, recursive:true);
            return result;
        }

        public async Task<Recipe> GetAsync(int id)
        {
            var result = await connection.Table<Recipe>().Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> UpdateAsync(Recipe recipe)
        {
           var result= await connection.UpdateAsync(recipe);
            return result;
        }
    }
}
