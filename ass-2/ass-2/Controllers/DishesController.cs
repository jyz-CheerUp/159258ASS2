using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ass_2.Data;
using ass_2.Models;
using ass_2.ViewModels;
using Eco.ViewModel.Runtime;
using PagedList;

namespace ass_2.Controllers
{
    public class DishesController : Controller
    {
        private ass_2Context db = new ass_2Context();


        public ActionResult Index(string category, string search,int? page,string sortBy)
        {
            DishIndexViewModel viewModel = new DishIndexViewModel();
           
            var dishes = db.Dishes.Include(p => p.Category);

            if (!String.IsNullOrEmpty(search))
            {
                dishes = dishes.Where(p => p.Name.Contains(search) ||
                                           p.material.Contains(search) ||
                                           p.Category.Name.Contains(search));

                viewModel.Search = search;
            }
            var categories = dishes.OrderBy(p => p.Category.Name).Select(p => p.Category.Name).Distinct();
            ViewBag.Categories = new SelectList(categories);
            viewModel.CatsWithCount = from matchingDishes in dishes
                                      where matchingDishes.CategoryID != null
                                      group matchingDishes by matchingDishes.Category.Name into catGroup
                                      select new CategoryWithCount()
                                      {
                                          CategoryName = catGroup.Key,
                                          DishCount = catGroup.Count()
                                      };

            if (!String.IsNullOrEmpty(category))
            {
                dishes = dishes.Where(p => p.Category.Name == category);
                viewModel.Category = category;

            }

            switch (sortBy)
            {

                case "order":
                    dishes = dishes.OrderBy(p => p.Name);
                    break;
                case "descending":
                    dishes = dishes.OrderByDescending(p => p.Name);
                    break;
                default:
                    dishes = dishes.OrderBy(p => p.Name);
                    break;
            }

            const int PageItems = 3;
            int currentpage = (page ?? 1);
            viewModel.Dishes = dishes.ToPagedList(currentpage, PageItems);
            viewModel.SortBy = sortBy;



            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Order","order"},
                {"Descending","descending" }
            };
            return View(viewModel);
        }




        // GET: Dishes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = db.Dishes.Find(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // GET: Dishes/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Dishes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,steps,material,Image,CategoryID")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(dish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", dish.CategoryID);
            return View(dish);
        }

        // GET: Dishes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = db.Dishes.Find(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", dish.CategoryID);
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,steps,material,Image,CategoryID")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", dish.CategoryID);
            return View(dish);
        }

        // GET: Dishes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = db.Dishes.Find(id);
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dish dish = db.Dishes.Find(id);
            db.Dishes.Remove(dish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
