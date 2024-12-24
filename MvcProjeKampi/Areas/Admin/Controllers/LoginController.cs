using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EntityLayer.Concretes.Admin p)
        {
            var adminValue = adm.LoginCheck(p);

            if (adminValue != null)
            {
                FormsAuthentication.SetAuthCookie(p.AdminUserName, false);
                Session["AdminUserName"] = p.AdminUserName;
                return RedirectToAction("Index", "Category");
            }
            return RedirectToAction("Index");
        }
    }
}