using Microsoft.AspNetCore.Mvc;
using WebAppProductsandCategories.Data;
using WebAppProductsandCategories.Models;

namespace WebAppProductsandCategories.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductData _dataAccess;
        private readonly CategoryData _dataAccessCat;

        // Inyectamos ambas capas de datos
        public ProductController(ProductData dataAccess, CategoryData dataAccessCategory)
        {
            _dataAccess = dataAccess;
            _dataAccessCat = dataAccessCategory;
        }

        // GET: /Product/
        public IActionResult Index()
        {
            var products = _dataAccess.GetProducts();
            ViewBag.Categories = GetCategories(); // Para resolver nombres de categorías
            return View(products);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories(); // Para llenar el <select> desplegable
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.CreateProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = GetCategories();
            return View(product);
        }

        // GET: /Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _dataAccess.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = GetCategories(); // Para llenar el <select> desplegable
            return View(product);
        }

        // POST: /Product/Edit
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dataAccess.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = GetCategories();
            return View(product);
        }

        // GET: /Product/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _dataAccess.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Product/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int ProductId)
        {
            _dataAccess.DeleteProduct(ProductId);
            return RedirectToAction("Index");
        }

        // Método auxiliar para obtener categorías
        private List<Category> GetCategories()
        {
            return _dataAccessCat.GetCategories();
        }
    }
}