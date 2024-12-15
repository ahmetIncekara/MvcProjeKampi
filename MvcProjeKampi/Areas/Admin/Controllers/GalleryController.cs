using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager im = new ImageFileManager(new EFImageFileDal());

        public ActionResult Index()
        {
            var imageFileValues = im.GetList();
            return View(imageFileValues);
        }
    }
}