using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TianWen.XiaoZhen1Qu.Web.Areas.Business
{
    public class BusinessAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Business";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Business_Default",
                "{controller}/{action}/{id}",
                new { controller = "sy", action = "sy", id = UrlParameter.Optional }
            );
        }
    }
}