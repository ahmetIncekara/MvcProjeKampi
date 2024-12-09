using EntityLayer.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");

            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Geçersiz mail adresi");

            RuleFor(x=>x.Subject).MinimumLength(3).WithMessage("En az 3 karakter olmalı");
            RuleFor(x=>x.UserName).MinimumLength(3).WithMessage("En az 3 karakter olmalı");

            RuleFor(x=>x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter olmalı");
        }
    }
}
