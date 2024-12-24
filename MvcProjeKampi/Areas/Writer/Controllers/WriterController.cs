using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class WriterController : BaseController
    {
        WriterManager wm = new WriterManager(new EFWriterDal());

        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult WriterProfile()
        {
            var value = wm.GetByID(CurrentWriter.WriterID);
            ViewBag.p = CurrentWriter.WriterMail;
            return View(value);
        }

        [HttpPost]
        public ActionResult WriterProfile(EntityLayer.Concretes.Writer p)
        {
            var writerResult = wm.WriterUpdate(p);
            if (writerResult.IsSuccess)
            {
                return RedirectToAction("AllHeading","Heading");
            }

            foreach (var error in writerResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(EntityLayer.Concretes.Writer p)
        {
            var writerResult = wm.WriterAdd(p);
            if (writerResult.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in writerResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(EntityLayer.Concretes.Writer p)
        {
            var writerResult = wm.WriterUpdate(p);
            if (writerResult.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in writerResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View();
        }
    }
}