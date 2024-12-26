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
        List<Message> GetListInbox(string WriterMail, string p);
        List<Message> GetListSendbox(string WriterMail);
        List<Message> GetListSendbox(string WriterMail, string p);
        List<Message> GetListDeleted(string WriterMail);
        MessageResult MessageAdd(Message message);
        Message GetByID(int id);
        int GetSendMessageCountByUser(string userMail);
        int GetReceiveMessageCountByUser(string userMail);
        void MessageDelete(int id);
        void MessageUpdate(Message message);

    }
}
