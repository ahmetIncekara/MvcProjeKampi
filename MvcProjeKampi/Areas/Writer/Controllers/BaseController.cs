using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class BaseController : Controller
    {
        protected EntityLayer.Concretes.Writer CurrentWriter;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var writerMail = (string)Session["WriterMail"];
            if (writerMail == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { action = "Index", controller = "Login" })
                );
            }
            else
            {
                WriterManager wm = new WriterManager(new EFWriterDal());
                CurrentWriter = wm.GetByWriterMail(writerMail);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}