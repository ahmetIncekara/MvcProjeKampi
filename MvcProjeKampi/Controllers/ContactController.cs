using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValue = cm.GetByID(id);
            return View(contactValue);
        }

        public PartialViewResult LeftSideMenu()
        {
            int contactCount = cm.GetContactCount();
            ViewBag.ContactCount = contactCount;
            int receiveMessageCount = mm.GetReceiveMessageCountByUser("admin@gmail.com");
            ViewBag.ReceiveMessageCount = receiveMessageCount;
            int sendMessageCount = mm.GetSendMessageCountByUser("admin@gmail.com");
            ViewBag.SendMessageCount = sendMessageCount;

            return PartialView();
        }

    }
}