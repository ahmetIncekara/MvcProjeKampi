using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer writer);
        Writer GetByID(int id);
        Writer GetByWriterMail(string writerMail);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer LoginCheck(Writer writer);

    }
}
