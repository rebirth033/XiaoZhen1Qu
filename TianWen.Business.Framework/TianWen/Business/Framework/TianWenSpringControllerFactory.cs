using Spring.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Spring.Context.Support;

namespace TianWen.Business.Framework.TianWen.Business.Framework
{
    public class TianWenSpringControllerFactory : DefaultControllerFactory
    {
        private static IApplicationContext _context;

        public TianWenSpringControllerFactory(IApplicationContext context)
        {
            _context = context;
        }

        protected virtual void AddActionInvokerTo(IController controller)
        {
            if ((controller != null) && typeof(Controller).IsAssignableFrom(controller.GetType()))
            {
                ((Controller)controller).ActionInvoker = new TianWenActionInvoker(ApplicationContext);
            }
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller;
            if (ApplicationContext.ContainsObjectDefinition(controllerName))
            {
                controller = ApplicationContext.GetObject(controllerName) as IController;
            }
            else
            {
                controller = base.CreateController(requestContext, controllerName);
            }
            this.AddActionInvokerTo(controller);
            return controller;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controllerInstance = null;
            if (controllerType != null)
            {
                IDictionary objectsOfType = ApplicationContext.GetObjectsOfType(controllerType);
                if (objectsOfType.Count > 0)
                {
                    controllerInstance = (IController)objectsOfType.Cast<DictionaryEntry>().First<DictionaryEntry>().Value;
                }
            }
            else
            {
                controllerInstance = base.GetControllerInstance(requestContext, controllerType);
            }
            this.AddActionInvokerTo(controllerInstance);
            return controllerInstance;
        }

        public static IApplicationContext ApplicationContext
        {
            get
            {
                if ((_context == null) || (_context.Name != ApplicationContextName))
                {
                    if (string.IsNullOrEmpty(ApplicationContextName))
                    {
                        _context = ContextRegistry.GetContext();
                    }
                    else
                    {
                        _context = ContextRegistry.GetContext(ApplicationContextName);
                    }
                }
                return _context;
            }
        }

        public static string ApplicationContextName { get; set; }
    }
}
