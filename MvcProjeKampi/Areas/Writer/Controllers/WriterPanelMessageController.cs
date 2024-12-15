using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageValues = mm.GetListInbox();
            return View(messageValues);
        }
    }
}