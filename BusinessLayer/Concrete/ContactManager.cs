using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);    
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
        public (int? previousId, int? nextId) GetPreviousAndNextMessageIds(int currentMessageId)
        {
            List<Contact> allMessages;


            allMessages = GetList().OrderBy(x => x.ContactID).ToList();
            
          
            int currentIndex = allMessages.FindIndex(m => m.ContactID == currentMessageId);

            int? previousId = currentIndex > 0 ? allMessages[currentIndex - 1].ContactID : (int?)null;
            int? nextId = currentIndex < allMessages.Count - 1 ? allMessages[currentIndex + 1].ContactID : (int?)null;

            return (previousId, nextId);
        }
    }
}
