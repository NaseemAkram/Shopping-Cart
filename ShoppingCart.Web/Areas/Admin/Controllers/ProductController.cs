using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess.Repositories;
using ShoppingCart.Models;

namespace ShoppingCart.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IUnitOfWork _unitofWork;
        private IWebHostEnvironment _hostingEnvironment;

        public ProductController(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }
        //#region APICALL

        //public IActionResult AllProducts()
        //{
        //    var products = _unitofWork.Product.GetAll(includeproperties: "Category");
        //    return Json(new { data = products });
        //}
        //#endregion

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitofWork.Product.GetAll();
            return View(products);
        }
    }
}
