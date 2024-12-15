using EntityLayer.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.concretes
{
    public class HeadingViewModel
    {
        public Heading Heading { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Writers { get; set; }
    }
}
