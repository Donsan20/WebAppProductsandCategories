using System.ComponentModel.DataAnnotations;

namespace WebAppProductsandCategories.Models
{
    public class Product
    {
        [Display(Name = "ID Producto")]
        public int ProductId { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string? Name { get; set; }

        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "Categoría")]
        public int CategoryId { get; set; } // Llave foránea hacia Category

        public Category? Category { get; set; }  // Propiedad de navegación
    }
}