using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using FluentValidation.Results;
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
        private MessageValidator _validator = new MessageValidator();


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

        public MessageResult MessageAdd(Message message)
        {
            ValidationResult validationResult = ValidateMessage(message);
            if (!validationResult.IsValid)
            {
                return new MessageResult(false, validationResult.Errors.Select(e => new ValidationError
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList());
            }

            _messageDal.Insert(message);
            return new MessageResult(true, null, message);
            
        }

        public ValidationResult ValidateMessage(Message message)
        {
            return _validator.Validate(message);
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
