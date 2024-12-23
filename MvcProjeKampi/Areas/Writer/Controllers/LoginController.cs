using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EntityLayer.Concretes.Writer p)
        {
            var writerValue = wm.LoginCheck(p);

            if (writerValue != null)
            {
                FormsAuthentication.SetAuthCookie(p.WriterMail, false);
                Session["WriterMail"] = p.WriterMail;
                return RedirectToAction("MyContent", "Content");
            }
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default", new { Area = "" });
        }
    }
}