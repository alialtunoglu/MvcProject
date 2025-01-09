using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.ViewModels;
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
            // Business Layer'daki GetPreviousAndNextMessageIds metodu çağrılıyor
            ContactNavigation(id);

            return View(contactValues);
        }
        public PartialViewResult RenderMailSidebar()
        {
            var viewModel = new MailSidebarViewModel
            {
                ContactCount = cm.GetList().Count(),
                InboxCount = mm.GetListInbox().Count(),
                SendboxCount = mm.GetListSendbox().Count(),
                DraftMailCount = mm.GetListSendbox(isDraft: true).Count(),
                SpamCount=65

            };

            // RenderMailSidebar Partial View'ini döndür.
            return PartialView("RenderMailSidebar", viewModel); // RenderMailSidebar adı burada kullanılır
        }
        public PartialViewResult ContactNavigation(int id)
        {
            var (previousId, nextId) = cm.GetPreviousAndNextMessageIds(id);
            
            var navigationModel = new MessageNavigationViewModel
            {
                PreviousMessageId = previousId,
                NextMessageId = nextId
            };

            return PartialView("ContactNavigation", navigationModel);
        }
    }
}