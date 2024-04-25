using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Models;
using SQLite;

namespace FoodRecipesApp.Services
{
    public class BaseServices: IBaseServices
    {
        public SQLiteAsyncConnection connection;
        public BaseServices()
        {
            SetupDatabase();
            
        }
        public async void SetupDatabase()
        {
            if(connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FoodRecipesApp.db");
                connection = new SQLiteAsyncConnection(dbPath);

                // Crear las tablas en la base de datos
                await connection.CreateTablesAsync<Procedure, Origin, Recipe>();
                
            }
        }
    }
}
