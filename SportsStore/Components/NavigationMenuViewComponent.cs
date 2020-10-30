using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.Models;
using System.Collections.Generic;
using SportsStore.Models.ViewModels;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            IEnumerable<string> categories = repository.Products
                  .Select(x => x.Category)
                  .Distinct()
                  .OrderBy(x => x);

            List<Category> cat = new List<Category>();
            foreach (string c in categories)
                cat.Add(new Category { Name = c });

            CategoringInfo ci = new CategoringInfo
            {
                TotalCategories = categories.Count(),
                Categories = cat
            };

            CategoryListViewModel clvm = new CategoryListViewModel
            {
                Categories = cat,
                CategoringInfo = ci
            };

            return View(clvm);
        }
    }
}