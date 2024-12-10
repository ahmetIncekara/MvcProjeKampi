using DataAccessLayer.Concrete;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName 
            && x.AdminPassword == p.AdminPassword);
            if (adminUserInfo != null)
            {
                RedirectToAction("Index", "AdminCategory");
            }
            return RedirectToAction("Index");
        }
    }
}