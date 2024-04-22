using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Models;

namespace FoodRecipesApp.Services
{
    public class OriginServices : BaseServices, IOriginService
    {
        public async Task<int> AddAsync(Origin origin)
        {
            if (origin is null)
                return (int)System.Net.HttpStatusCode.BadRequest;
            int result= await connection.InsertAsync(origin);
            return result;
        }

        public async Task<int> DeleteAsync(Origin origin)
        {
           var result= await connection?.DeleteAsync(origin);
            return result;
        }

        public async Task<List<Origin>> GetAllAsync()
        {
            var result= await connection.Table<Origin>().ToListAsync();
            return result;
        }

        public async Task<int> UpdateAsync(Origin origin)
        {
            var result= await connection.UpdateAsync(origin);
            return result;
        }
    }
}
