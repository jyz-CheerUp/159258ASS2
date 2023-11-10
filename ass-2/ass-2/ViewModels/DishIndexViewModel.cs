using ass_2.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace ass_2.ViewModels
{
    public class DishIndexViewModel
    {
      //  public IQueryable<Dish> Products { get; set; }
      public IPagedList<Dish> Dishes { get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        public string Category { get; set; }
        public string SortBy { get;internal set; }
        public Dictionary<string, string> Sorts { get; set; }

        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }

        public IQueryable<Dish> Dishes1 { get; internal set; }
    }

    public class CategoryWithCount
    {
        public int DishCount { get; set; }
        public string CategoryName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return CategoryName + " (" +
                DishCount.ToString() + ")";
            }
        }
    }

}
