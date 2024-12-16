using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();

            
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
               
            
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p,string button)
        {
            ValidationResult validationResult = messageValidator.Validate(p);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    p.SenderMail = "admin@gmail.com";
                    p.IsDraft = false;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
            }
            else if (button == "draft")
            {
                if (validationResult.IsValid)
                {

                    p.SenderMail = "admin@gmail.com";
                    p.IsDraft = true;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAdd(p);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            // Şu anki mesajı al
            var messageValues = mm.GetById(id);

            // Business Layer'daki GetPreviousAndNextMessageIds metodu çağrılıyor
            var (previousId, nextId) = mm.GetPreviousAndNextMessageIds(id,"inbox");

            // ViewBag ile view'a gönderiyoruz
            ViewBag.PreviousMessageId = previousId;
            ViewBag.NextMessageId = nextId;

            return View(messageValues);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messageValues = mm.GetById(id);

            // Business Layer'daki GetPreviousAndNextMessageIds metodu çağrılıyor
            var (previousId, nextId) = mm.GetPreviousAndNextMessageIds(id,"sendbox");
            // ViewBag ile view'a gönderiyoruz
            ViewBag.PreviousMessageId = previousId;
            ViewBag.NextMessageId = nextId;

            return View(messageValues);
        }
        public ActionResult GetDraftDetails(int id)
        {
            var result = mm.GetById(id);
            return View(result);
        }
        public ActionResult Draft()
        {
            var result = mm.IsDraft();
            return View(result);
        }

    }
}