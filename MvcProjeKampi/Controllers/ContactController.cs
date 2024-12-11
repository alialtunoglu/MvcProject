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
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id )
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }
        public PartialViewResult RenderMailSidebar()
        {
            var contact = cm.GetList().Count();
            
            var messageListIn = mm.GetListInbox();
            var inboxCount = messageListIn.Count();

            var messageListSend = mm.GetListSendbox();
            var sendboxCount = messageListSend.Count();
            ViewBag.contact = contact;
            ViewBag.InboxCount = inboxCount;
            ViewBag.SendboxCount = sendboxCount;
            var draftMail = mm.GetListSendbox(isDraft:true).Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            return PartialView();
        }
    }
}