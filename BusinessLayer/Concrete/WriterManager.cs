using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        private WriterValidator _validator = new WriterValidator();

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x=>x.WriterID==id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public Writer LoginCheck(Writer writer)
        {
            var hashedPassword = ComputeSha1Hash(writer.WriterPassword);
            var adminValue = _writerDal.Get(x => x.WriterMail == writer.WriterMail
            && x.WriterPassword == hashedPassword);
            return adminValue;
        }

        private string ComputeSha1Hash(string password)
        {
            using (var sha1 = SHA1.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = sha1.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public WriterResult WriterAdd(Writer writer)
        {
            ValidationResult validationResult = ValidateWriter(writer);
            if (!validationResult.IsValid)
            {
                return new WriterResult(false, validationResult.Errors.Select(e => new ValidationError
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList());
            }

            _writerDal.Insert(writer);
            return new WriterResult(true, null, writer);
        }

        public ValidationResult ValidateWriter(Writer writer)
        {
            return _validator.Validate(writer);
        }


        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public WriterResult WriterUpdate(Writer writer)
        {
            ValidationResult validationResult = ValidateWriter(writer);
            if (!validationResult.IsValid)
            {
                return new WriterResult(false, validationResult.Errors.Select(e => new ValidationError
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList());
            }

            _writerDal.Update(writer);
            return new WriterResult(true, null, writer);
        }

        public Writer GetByWriterMail(string writerMail)
        {
            return _writerDal.Get(x=>x.WriterMail == writerMail);
        }
    }
}
