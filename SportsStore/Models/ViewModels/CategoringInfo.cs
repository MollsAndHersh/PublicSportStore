using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class CategoringInfo
    {
        public int TotalCategories;
        public List<Category> Categories { get; internal set; }
        public string CurrentCategory { get; internal set; }
    }
}
