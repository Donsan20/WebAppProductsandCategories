using Microsoft.AspNetCore.Mvc;
using WebAppProductsandCategories.Data;
using WebAppProductsandCategories.Models;

namespace WebAppProductsandCategories.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryData _dataAccess;

        // Inyección de dependencia de CategoryData por constructor
        public CategoryController(CategoryData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: /Category/
        public IActionResult Index()
        {
            var categories = _dataAccess.GetCategories();
            return View(categories);
        }

        // GET: /Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.CreateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Category/Edit/5
        public IActionResult Edit(int id)
        {
            var category = _dataAccess.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: /Category/Edit
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Category/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _dataAccess.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: /Category/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int CategoryId)
        {
            _dataAccess.DeleteCategory(CategoryId);
            return RedirectToAction("Index");
        }
    }
}