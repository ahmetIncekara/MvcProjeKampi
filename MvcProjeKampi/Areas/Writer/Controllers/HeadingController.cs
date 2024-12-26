using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcProjeKampi.Controllers;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class HeadingController : BaseController
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());


        public ActionResult MyHeading()
        {
            var headingValues = hm.GetListByWriter(CurrentWriter.WriterID);
            return View(headingValues);
        }

        public ActionResult AllHeading(int p = 1)
        {
            var headingValues = hm.GetList().ToPagedList(p, 4);
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValues = GetCategoryList();
            ViewBag.categoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Now;
            p.HeadingStatus = true;
            p.WriterID = CurrentWriter.WriterID;
            var headingResult = hm.HeadingAdd(p);
            if (headingResult.IsSuccess)
            {
                return RedirectToAction("MyHeading");
            }

            foreach (var error in headingResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            ViewBag.categoryValues = GetCategoryList();
            return View(p);
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValues = GetCategoryList();
            ViewBag.categoryValues = categoryValues;

            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            //ValidationResult result = headingValidator.Validate(p);
            //if (result.IsValid)
            //{
            //    p.HeadingStatus = true;
            //    _headingService.HeadingUpdate(p);
            //    return RedirectToAction("MyHeading");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //ViewBag.categoryValues = GetCategoryList();
            return View(p);

        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

        private List<SelectListItem> GetCategoryList()
        {
            return cm.GetList()
                     .Select(x => new SelectListItem
                     {
                         Text = x.CategoryName,
                         Value = x.CategoryID.ToString()
                     })
                     .ToList();
        }
    }
}