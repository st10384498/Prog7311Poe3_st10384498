using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgriConnect_POE7311_Part3.Models
{
    internal class ProductFilterViewModel
    {
        public int? CategoryId { get; set; }
        public List<Product> Products { get; set; }
        public SelectList Categories { get; set; }
    }
}