using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class MessageController : BaseController
    {
        //ContactManager cm = new ContactManager(new EFContactDal());
        MessageManager mm = new MessageManager(new EFMessageDal());

        public ActionResult Inbox()
        {
            var messageValues = mm.GetListInbox(CurrentWriter.WriterMail);
            return View(messageValues);
        }

        public ActionResult Sendbox()
        {
            var messageValues = mm.GetListSendbox(CurrentWriter.WriterMail);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(EntityLayer.Concretes.Message p)
        {
            p.MessageDate = DateTime.Now;
            p.SenderMail = CurrentWriter.WriterMail;
            p.Read = false;
            var messageResult = mm.MessageAdd(p);
            if (messageResult.IsSuccess)
            {
                return RedirectToAction("Sendbox");
            }

            foreach (var error in messageResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View();
        }


        public ActionResult GetReceiveMessageDetails(int id)
        {
            var messageValue = mm.GetByID(id);
            messageValue.Read = true;
            mm.MessageUpdate(messageValue);
            return View(messageValue);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var messageValue = mm.GetByID(id);
            return View(messageValue);
        }

        public PartialViewResult LeftSideMenu()
        {
            //int contactCount = cm.GetContactCount();
            //ViewBag.ContactCount = contactCount;
            int receiveMessageCount = mm.GetReceiveMessageCountByUser(CurrentWriter.WriterMail);
            ViewBag.ReceiveMessageCount = receiveMessageCount;
            int sendMessageCount = mm.GetSendMessageCountByUser(CurrentWriter.WriterMail);
            ViewBag.SendMessageCount = sendMessageCount;

            return PartialView();
        }

    }
}