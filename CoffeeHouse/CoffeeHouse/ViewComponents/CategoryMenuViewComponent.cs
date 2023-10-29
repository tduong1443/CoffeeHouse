using CoffeeHouse.Models;
using CoffeeHouse.Reponsitory;
using Microsoft.AspNetCore.Mvc;
namespace CoffeeHouse.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryReponsitory icategory;
        public CategoryMenuViewComponent(ICategoryReponsitory icategory)
        {
            this.icategory = icategory;
        }

        public IViewComponentResult Invoke()
        {
            var category = icategory.GetAllCategory().OrderBy(x => x.IdCategory);
            return View(category);
        }

    }
}
