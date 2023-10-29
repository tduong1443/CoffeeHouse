using CoffeeHouse.Data;
using CoffeeHouse.Models;

namespace CoffeeHouse.Reponsitory
{
    public class CategoryReponsitory : ICategoryReponsitory
    {
        private CoffeeHouseContext db;

        public CategoryReponsitory(CoffeeHouseContext db)
        {
            this.db = db;
        }

        public Category Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }

        public Category Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Category Get(string Id)
        {
            return db.Categories.Find(Id);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return db.Categories;
        }

        public Category Update(Category category)
        {
            db.Update(category);
            db.SaveChanges();
            return category;
        }
    }
}
