using CoffeeHouse.Reponsitory;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHouse.ViewComponents
{
    public class MenuCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryReponsitory icategory;
        public MenuCategoryViewComponent(ICategoryReponsitory icategory)
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
