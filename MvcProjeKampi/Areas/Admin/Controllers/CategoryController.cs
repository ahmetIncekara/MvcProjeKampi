using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        [Authorize]
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDelete(categoryValue);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByID(id);

            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);

            return RedirectToAction("Index");
        }
    }
}