using EntityLayer.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");

            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçersiz mail adresi");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter olmalı");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En az 3 karakter olmalı");
            RuleFor(x => x.MessageContent).MinimumLength(3).WithMessage("En az 3 karakter olmalı");
        }
    }
}
