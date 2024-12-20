using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concretes
{
    public class MessageResult
    {
        public bool IsSuccess { get; set; }
        public List<ValidationError> Errors { get; set; }
        public Message Messsage { get; set; }

        public MessageResult(bool isSuccess, List<ValidationError> errors = null, Message message = null)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<ValidationError>();
            Messsage = message ?? new Message();
        }

    }
}
