using BusinessLayer.Abstract;
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

        public ActionResult Deletedbox()
        {
            var messageValues = mm.GetListDeleted(CurrentWriter.WriterMail);
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

        public ActionResult InboxDelete(List<int> SelectedMessageIds)
        {
            if (SelectedMessageIds == null || !SelectedMessageIds.Any())
            {
                TempData["Message"] = "Hiçbir mesaj seçilmedi.";
                return RedirectToAction("Inbox");
            }

            foreach (var messageId in SelectedMessageIds)
            {
                mm.MessageDelete(messageId);
            }

            TempData["Message"] = "Seçili mesajlar başarıyla işlendi.";
            return RedirectToAction("Inbox");
        }

        public ActionResult SendboxDelete(List<int> SelectedMessageIds)
        {
            if (SelectedMessageIds == null || !SelectedMessageIds.Any())
            {
                TempData["Message"] = "Hiçbir mesaj seçilmedi.";
                return RedirectToAction("Sendbox");
            }

            foreach (var messageId in SelectedMessageIds)
            {
                mm.MessageDelete(messageId);
            }

            TempData["Message"] = "Seçili mesajlar başarıyla işlendi.";
            return RedirectToAction("Sendbox");
        }

        public ActionResult RecycleDelete(List<int> SelectedMessageIds)
        {
            if (SelectedMessageIds == null || !SelectedMessageIds.Any())
            {
                TempData["Message"] = "Hiçbir mesaj seçilmedi.";
                return RedirectToAction("Deletedbox");
            }

            foreach (var messageId in SelectedMessageIds)
            {
                mm.MessageDelete(messageId);
            }

            TempData["Message"] = "Seçili mesajlar başarıyla işlendi.";
            return RedirectToAction("Deletedbox");
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