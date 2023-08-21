using Microsoft.AspNetCore.Mvc;
using MvcWeb.Data;
using MvcWeb.Models;

namespace MvcWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MySqlDb _db;

        public CategoryController(MySqlDb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot match Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Category created sucessfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? obj = _db.Categories.Find(id);
            return obj switch
            {
                null => NotFound(),
                _ => View(obj)
            };
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Category edited sucessfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? obj = _db.Categories.Find(id);
            return obj switch
            {
                null => NotFound(),
                _ => View(obj)
            };
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category obj = _db.Categories.Find(id)!;
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["sucess"] = "Category deleted sucessfully";
            return RedirectToAction("Index");
        }
    }
}
