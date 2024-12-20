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
        WriterResult WriterAdd(Writer writer);
        Writer GetByID(int id);
        Writer GetByWriterMail(string writerMail);
        void WriterDelete(Writer writer);
        WriterResult WriterUpdate(Writer writer);
        Writer LoginCheck(Writer writer);

    }
}
