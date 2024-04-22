using FoodRecipesApp.Models;

namespace FoodRecipesApp.Interfaces
{
    public interface IProcedureServices
    {
        Task<int> AddAsync(Procedure procedure);
        Task<int> UpdateAsync(Procedure procedure);
        Task<int> DeleteAsync(Procedure procedure);
        Task<List<Procedure>> GetAllAsync();
        Task<Procedure> GetAsync(int id);
        Task<List<Procedure>> GetAllByRecipeIdAsync(int procedureId);
    }
}
