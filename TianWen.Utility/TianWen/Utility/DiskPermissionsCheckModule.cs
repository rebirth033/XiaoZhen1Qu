namespace TianWen.Utility
{
    using System;
    using System.Security;
    using System.Security.AccessControl;
    using System.Security.Permissions;
    using System.Web;
    using TianWen.Interface;

    public class DiskPermissionsCheckModule : IHttpModule
    {
        private static bool bool_0;

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.method_0);
        }

        private void method_0(object sender, EventArgs e)
        {
            smethod_0(sender, e);
        }

        private static void smethod_0(object sender, EventArgs e)
        {
            if (!bool_0)
            {
                string applicationPath = EnvironmentVar.ApplicationPath;
                FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.AllAccess, AccessControlActions.Change, applicationPath);
                try
                {
                    permission.Demand();
                    bool_0 = true;
                }
                catch (SecurityException exception)
                {
                    bool_0 = false;
                    throw new Exception(string.Format("设置目录【{0}】的访问权限失败，请手工给此目录，配置为IIS可以完全控制。", applicationPath), exception);
                }
            }
        }
    }
}

