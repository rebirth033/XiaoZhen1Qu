namespace TianWen.Framework.Common.Spring
{
    using AopAlliance.Aop;
    using AopAlliance.Intercept;
    using System;
    using TianWen.Framework.Log;

    public class BaseMethodInterceptor : IMethodInterceptor, IInterceptor, IAdvice
    {
        protected virtual void afterInvoke(IMethodInvocation invocation)
        {
            LoggerManager.Debug(base.GetType().Name, "end-" + invocation.TargetType.ToString());
        }

        protected virtual void beforeInvoke(IMethodInvocation invocation)
        {
            LoggerManager.Debug(base.GetType().Name, "begin-" + invocation.TargetType.ToString());
        }

        public object Invoke(IMethodInvocation invocation)
        {
            this.beforeInvoke(invocation);
            object obj2 = invocation.Proceed();
            this.afterInvoke(invocation);
            return obj2;
        }
    }
}

