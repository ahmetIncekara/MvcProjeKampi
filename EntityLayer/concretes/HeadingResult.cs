using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concretes
{
    public class HeadingResult
    {
        public bool IsSuccess { get; set; }
        public List<ValidationError> Errors { get; set; }
        public Heading Heading { get; set; }

        public HeadingResult(bool isSuccess, List<ValidationError> errors = null, Heading heading = null)
        {
            IsSuccess = isSuccess;
            Errors = errors ?? new List<ValidationError>();
            Heading = heading ?? new Heading();
        }
    }
}
