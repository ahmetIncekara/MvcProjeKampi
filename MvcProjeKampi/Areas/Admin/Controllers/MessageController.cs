using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageValues = mm.GetListInbox();
            return View(messageValues);
        }

        public ActionResult Sendbox()
        {
            var messageValues = mm.GetListSendbox();
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult validationResult = messageValidator.Validate(p);
            if (validationResult.IsValid)
            {
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
    }
}