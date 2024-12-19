using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        public ActionResult MyContent()
        {
            var writerMail = (string)Session["WriterMail"];
            var writerValue = wm.GetByWriterMail(writerMail);
            var contentValues = cm.GetListByWriter(writerValue.WriterID);
            return View(contentValues);

        }
    }
}