using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess.Repositories;
using ShoppingCart.DataAccess.ViewModel;

namespace ShoppingCart.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private IUnitOfWork _unitofWork;
        public CategoryController(IUnitOfWork unitofwork)
        {
            _unitofWork = unitofwork;
        }
        public IActionResult Index()
        {
            CategoryVM categoryvm = new CategoryVM();
            categoryvm.Categories = _unitofWork.Category.GetAll();
            return View(categoryvm);
        }
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Category = _unitofWork.Category.GetT(x => x.Id == id);
                if (vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }

        }


        [HttpPost]

        public IActionResult CreateUpdate(CategoryVM vM)
        {
            if (ModelState.IsValid)
            {
                if (vM.Category.Id == 0)
                {
                    _unitofWork.Category.Add(vM.Category);
                    TempData["success"] = "Category Created Done";
                }
                else
                {
                    _unitofWork.Category.Update(vM.Category);
                    TempData["success"] = "Category updated Done";
                }


                _unitofWork.Save();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        [HttpGet]

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitofWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitofWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitofWork.Category.Delete(category);
            _unitofWork.Save();
            TempData["success"] = "Category Deleted Successfully ";
            return RedirectToAction("Index");
        }
    }
}
