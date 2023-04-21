using ShoppingCart.DataAccess.Data;
using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Repositories
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categorydb = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categorydb != null)
            {
                categorydb.Name = category.Name;
                categorydb.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
