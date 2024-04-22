using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FoodRecipesApp.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public string TimeNeeded { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [OneToMany(CascadeOperations=CascadeOperation.All)]
        public List<Procedure> Procedures { get; set; }
        public Origin Origin { get; set; }
        [ForeignKey(typeof(Origin))]
        public int OriginId { get; set; }
    }
}
