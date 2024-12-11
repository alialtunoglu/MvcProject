using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x=>x.MessageID==id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x=>x.ReceiverMail=="admin@gmail.com");


        }
        public List<Message> GetListSendbox(bool isDraft=false)
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.IsDraft==isDraft);

        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);    
        }
        public List<Message> IsDraft()
        {
            return _messageDal.List(m => m.IsDraft == true);
        }
        public (int? previousId, int? nextId) GetPreviousAndNextMessageIds(int currentMessageId)
        {
            var allMessages = GetListInbox().OrderBy(x => x.MessageID).ToList();
            int currentIndex = allMessages.FindIndex(m => m.MessageID == currentMessageId);

            int? previousId = currentIndex > 0 ? allMessages[currentIndex - 1].MessageID : (int?)null;
            int? nextId = currentIndex < allMessages.Count - 1 ? allMessages[currentIndex + 1].MessageID : (int?)null;

            return (previousId, nextId);
        }
    }
}
