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
        MessageValidator messageValidator = new MessageValidator();

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
            ValidationResult validationResult = messageValidator.Validate(p);
            if (validationResult.IsValid)
            {
                p.SenderMail = CurrentWriter.WriterMail;
                p.MessageDate = DateTime.Now;
                p.Read = false;
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
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