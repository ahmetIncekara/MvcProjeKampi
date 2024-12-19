using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string WriterMail);
        List<Message> GetListSendbox(string WriterMail);
        void MessageAdd(Message message);
        Message GetByID(int id);
        int GetSendMessageCountByUser(string userMail);
        int GetReceiveMessageCountByUser(string userMail);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);

    }
}
