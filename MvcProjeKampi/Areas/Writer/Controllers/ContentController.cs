using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}