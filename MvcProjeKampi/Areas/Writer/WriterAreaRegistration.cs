using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer
{
    public class WriterAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Writer";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Writer_default",
                url: "Writer/{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcProjeKampi.Areas.Writer.Controllers" }
            );
        }
    }
}