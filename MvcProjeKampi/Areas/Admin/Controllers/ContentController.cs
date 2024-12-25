using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentAll(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var values = cm.GetList(p);
                return View(values);
            }
            else
            {
                var values = cm.GetList();
                return View(values);
            }
        }

        public ActionResult ContentByHeading(int id)
        {
            var values = cm.GetListByHeadingID(id);
            return View(values);
        }


    }
}