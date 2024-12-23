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
    public class DefaultController : Controller
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
    }
}