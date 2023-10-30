using CoffeeHouse.Models;

namespace CoffeeHouse.Reponsitory
{
    public interface ICategoryReponsitory
    {
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(string Id);
        Category Get(string Id);
        IEnumerable<Category> GetAllCategory();
    }
}
