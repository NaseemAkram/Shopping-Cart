using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.ViewModel
{
    public class CategoryVM
    {

        public Category Category { get; set; } = new Category();

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
