using ShoppingCart.DataAccess.Data;
using ShoppingCart.Models;

namespace ShoppingCart.DataAccess.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productdb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productdb != null)
            {
                productdb.Name = product.Name;
                productdb.Description = product.Description;
                productdb.Price = product.Price;


                if (product.ImageUrl != null)
                {
                    productdb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
