using System.ComponentModel.DataAnnotations;

namespace WebAppProductsandCategories.Models
{
    public class Category
    {
        [Display(Name = "ID Categoría")]
        public int CategoryId { get; set; }

        [Display(Name = "Nombre de la Categoría")]
        public string? Name { get; set; }
    }
}
