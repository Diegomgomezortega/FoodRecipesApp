using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Models;
using SQLiteNetExtensionsAsync.Extensions;

namespace FoodRecipesApp.Services
{
    public class ProcedureServices : BaseServices, IProcedureServices
    {
        public async Task<int> AddAsync(Procedure procedure)
        {
            if (procedure is null)
                return (int)System.Net.HttpStatusCode.BadRequest;
            int result = await connection.InsertAsync(procedure);
            return result;
        }

        public async Task<int> DeleteAsync(Procedure procedure)
        {
            var result = await connection?.DeleteAsync(procedure);
            return result;
        }

        public async Task<List<Procedure>> GetAllAsync()
        {
            var result = await connection.GetAllWithChildrenAsync<Procedure>(recursive:true);
            if (result.Count == 0) return null;
            return result.ToList();
        }

        public async Task<List<Procedure>> GetAllByRecipeIdAsync(int recipeId)
        {
            var result = await connection.GetAllWithChildrenAsync<Procedure>(x=>x.RecipeId==recipeId, recursive: true);
            if (result.Count == 0) return null;
            return result.ToList();
        }

        public async Task<Procedure> GetAsync(int id)
        {
            var result = await connection.Table<Procedure>().Where(x=>x.Id==id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> UpdateAsync(Procedure procedure)
        {
            var result = await connection.UpdateAsync(procedure);
            return result;
        }
    }
}
