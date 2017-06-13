using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Spring.Context;

namespace TianWen.Business.Framework.TianWen.Business.Framework
{
    public class TianWenActionInvoker : ControllerActionInvoker
    {
        private readonly IApplicationContext _context;

        public TianWenActionInvoker(IApplicationContext context)
        {
            this._context = context;
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            FilterInfo filters = base.GetFilters(controllerContext, actionDescriptor);
            foreach (IActionFilter filter in from f in filters.ActionFilters
                                             where f != null
                                             select f)
            {
                this._context.ConfigureObject(filter, filter.GetType().FullName);
            }
            foreach (IAuthorizationFilter filter2 in from f in filters.AuthorizationFilters
                                                     where f != null
                                                     select f)
            {
                this._context.ConfigureObject(filter2, filter2.GetType().FullName);
            }
            foreach (IExceptionFilter filter3 in from f in filters.ExceptionFilters
                                                 where f != null
                                                 select f)
            {
                this._context.ConfigureObject(filter3, filter3.GetType().FullName);
            }
            foreach (IResultFilter filter4 in from f in filters.ResultFilters
                                              where f != null
                                              select f)
            {
                this._context.ConfigureObject(filter4, filter4.GetType().FullName);
            }
            return filters;
        }
    }
}
