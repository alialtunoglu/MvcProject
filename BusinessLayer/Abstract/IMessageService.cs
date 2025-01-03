﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox(bool isDraft);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        Message GetById(int id);
        List<Message> IsDraft();
        
        (int? previousId, int? nextId) GetPreviousAndNextMessageIds(int currentMessageId,string inboxOrSendbox);


    }
}
