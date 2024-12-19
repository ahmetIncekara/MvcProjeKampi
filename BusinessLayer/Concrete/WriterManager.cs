using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
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

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public Writer GetByWriterMail(string writerMail)
        {
            return _writerDal.Get(x=>x.WriterMail == writerMail);
        }
    }
}
