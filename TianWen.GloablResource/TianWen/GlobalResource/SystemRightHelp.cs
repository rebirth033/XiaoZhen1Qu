using TianWen.Interface;

namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.ObjectModel;

    [Obsolete("该类已过期，请使用 ComponentFactory.Get<ISystemRightDao>()来进行数据访问")]
    public class SystemRightHelp
    {
        private static ISystemRightDao isystemRightDao_0 = ComponentFactory.Get<ISystemRightDao>("SystemRightDao");

        public int AddSystemRight(SystemRight right)
        {
            return isystemRightDao_0.AddSystemRight(right);
        }

        public int DeleteSystemRight(SystemRight right)
        {
            return isystemRightDao_0.DeleteSystemRight(right);
        }

        public static SystemRight GetSystemRight(string rightType, string rightId)
        {
            return isystemRightDao_0.GetSystemRight(rightType, rightId);
        }

        public static Collection<SystemRight> GetSystemRights(string rightType)
        {
            return new Collection<SystemRight>(isystemRightDao_0.GetSystemRights(rightType));
        }

        public static bool HasSystemRight(string rightType, string rightId)
        {
            return isystemRightDao_0.HasRight(rightType, rightId);
        }

        public static bool HasSystemRightType(string rightType)
        {
            return isystemRightDao_0.HasRight(rightType, "");
        }

        public int UpdateSystemRight(SystemRight right)
        {
            return isystemRightDao_0.UpdateSystemRight(right);
        }
    }
}

