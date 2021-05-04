using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetCategoryList();
            return View(categoryValues);
        }


        //public ActionResult AddCategory(Category category)
        //{
        //    CategoryValidator categoryValidator = new CategoryValidator();
        //    ValidationResult validationResult = categoryValidator.Validate(category);
        //    if (validationResult.IsValid)
        //    {
        //        categoryManager.CategoryAdd(category);
        //        return RedirectToAction("GetCategoryList");
        //    }
        //    else
        //    {
        //        foreach (var item in validationResult.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return RedirectToAction("GetCategoryList");
        //}

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("GetCategoryList");


        }

    }
}