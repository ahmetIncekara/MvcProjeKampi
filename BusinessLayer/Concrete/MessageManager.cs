using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
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

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string WriterMail)
        {
            return _messageDal.List(x => x.ReceiverMail == WriterMail);
        }

        public List<Message> GetListSendbox(string WriterMail)
        {
            return _messageDal.List(x => x.SenderMail == WriterMail);
        }

        public int GetReceiveMessageCountByUser(string userMail)
        {
            return _messageDal.Count(x => x.ReceiverMail == userMail && x.Read == false);
        }
        public int GetSendMessageCountByUser(string userMail)
        {
            return _messageDal.Count(x => x.SenderMail == userMail);
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
    }
}
