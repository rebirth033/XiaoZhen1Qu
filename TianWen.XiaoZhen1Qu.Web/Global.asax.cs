using Spring.Context;
using Spring.Web.Mvc;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TianWen.Framework.Common;

namespace TianWen.XiaoZhen1Qu.Web
{
    public class MvcApplication : SpringMvcApplication
    {
        static IApplicationContext Context;
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{ajaxpro}/{.*}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "sy", action = "sy", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected override void ConfigureApplicationContext()
        {
            //加载相关Spring配置文件
            //Context = SpringHelper.InitSpringContext();
        }

        protected override void RegisterSpringControllerFactory()
        {

            TianWen.Business.Framework.TianWen.Business.Framework.TianWenSpringControllerFactory tscf = new TianWen.Business.Framework.TianWen.Business.Framework.TianWenSpringControllerFactory(Context);
            ControllerBuilder.Current.SetControllerFactory(tscf);

        }

        protected override void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            this.RegisterRoutes(RouteTable.Routes);
            RegisterGlobalFilters(GlobalFilters.Filters);

            Context = SpringHelper.InitSpringContext();
            TianWenAppConfig.AppUrlBase = HttpContext.Current.Request.ApplicationPath == "/" ? "" : HttpContext.Current.Request.ApplicationPath;
        }
    }
}
