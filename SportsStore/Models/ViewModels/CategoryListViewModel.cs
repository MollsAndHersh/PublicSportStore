using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public CategoringInfo CategoringInfo { get; set; }
    }
}
