using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : BaseController
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult Headings()
        {
            var values = hm.GetList();
            return View(values);
        }

        public PartialViewResult Index(int id = 0)
        {
            if (id == 0)
            {
                var values = cm.GetList();
                return PartialView(values);
            }
            else
            {
                var values = cm.GetListByHeadingID(id);
                return PartialView(values);
            }
        }

        public PartialViewResult UserDataScreen()
        {
            ViewData["ID"] = 0;
            ViewData["Name"] = "";
            ViewData["Image"] = "";

            if (CurrentWriter.WriterID > 0)
            {
                ViewData["ID"] = CurrentWriter.WriterID;
                ViewData["Name"] = CurrentWriter.WriterName + " " + CurrentWriter.WriterSurName;
                ViewData["Image"] = CurrentWriter.WriterImage;
            }
            return PartialView();
        }

    }
}