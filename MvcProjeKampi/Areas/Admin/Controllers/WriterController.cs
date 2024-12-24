using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDal());

        public ActionResult Index()
        {
            var values = wm.GetList();
            return View(values);
        }
    }
}