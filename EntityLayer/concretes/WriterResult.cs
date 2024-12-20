using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concretes
{
    public class WriterResult
    {
        public bool IsSuccess { get; set; }
        public List<ValidationError> Errors { get; set; }
        public Writer Writer { get; set; }

        public WriterResult(bool isSuccess, List<ValidationError> errors = null, Writer writer = null)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<ValidationError>();
            Writer = writer ?? new Writer();
        }
    }
}
