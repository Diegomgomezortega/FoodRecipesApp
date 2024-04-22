using FoodRecipesApp.Models;
using SQLite;

namespace FoodRecipesApp.Services
{
    public class BaseServices
    {
        public SQLiteAsyncConnection connection;
        public BaseServices()
        {
            SetupDatabase();
            
        }
        private async void SetupDatabase()
        {
            if(connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FoodRecipesApp.db3");
                connection = new SQLiteAsyncConnection(dbPath);
                await connection.CreateTablesAsync<Procedure, Origin, Recipe>();
            }
        }
    }
}
