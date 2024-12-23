using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class ContentController : BaseController
    {
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult MyContent()
        {
            var contentValues = cm.GetListByWriter(CurrentWriter.WriterID);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult NewContent(int id)
        {
            ViewBag.HeadingID = id;
            return View();
        }

        [HttpPost]
        public ActionResult NewContent(Content p)
        {
            p.ContentDate = DateTime.Now;
            p.WriterID = CurrentWriter.WriterID;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
    }
}