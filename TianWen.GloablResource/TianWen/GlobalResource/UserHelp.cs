using TianWen.Interface;

namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using TianWen.Exceptions;

    [Obsolete("该类已过期，请使用 ComponentFactory.Get<IUserDao>()来进行数据访问")]
    public class UserHelp
    {
        private static IUserDao iuserDao_0 = ComponentFactory.Get<IUserDao>("UserDao");

        public static Collection<User> GetAllUser()
        {
            return new Collection<User>(iuserDao_0.GetAllUser(false));
        }

        public static Collection<User> GetAllUser(bool bool_0)
        {
            return new Collection<User>(iuserDao_0.GetAllUser(bool_0));
        }

        public static Collection<UserView> GetAllUserView()
        {
            return new Collection<UserView>(iuserDao_0.GetAllUserView());
        }

        public static string GetFlowRight(string UserId, string FlowId, string StepId)
        {
            return string.Join("+", iuserDao_0.GetFlowRight(UserId, FlowId, StepId).ToArray<string>());
        }

        public static User GetUser(string UserId)
        {
            return iuserDao_0.GetUserById(UserId);
        }

        public static User GetUser(string UserId, bool includeRights)
        {
            User user = GetUser(UserId);
            if (includeRights)
            {
                user.Rights = new Collection<UserRight>(iuserDao_0.GetUserRightByUserId(UserId));
            }
            return user;
        }

        public static User GetUser(string LogId, string OrgId)
        {
            return iuserDao_0.GetUserByLogId(LogId, OrgId);
        }

        public static string GetUserAllRight(string userId)
        {
            return GetUserAllRightValue(GetUserAllRightData(userId));
        }

        public static string GetUserAllRight(string userId, string appCode)
        {
            return GetUserAllRightValue(GetUserAllRightData(userId, appCode));
        }

        public static DataView GetUserAllRightData(string userId)
        {
            return iuserDao_0.GetUserAllRightData(userId);
        }

        public static DataView GetUserAllRightData(string userId, string appCode)
        {
            return iuserDao_0.GetUserAllRightData(userId, appCode);
        }

        public static string GetUserAllRightValue(DataView dataView_0)
        {
            string[] strArray = dataView_0[0]["allRight"].ToString().Split(new char[] { '*' });
            string str2 = string.Empty;
            if (strArray.Length <= 1)
            {
                return string.Empty;
            }
            string str3 = strArray[0].ToString();
            string str4 = strArray[1].ToString();
            string[] strArray2 = str3.Split(new char[] { ',' });
            string[] strArray3 = str4.Split(new char[] { ',' });
            for (int i = 0; i < strArray2.Length; i++)
            {
                for (int j = 0; j < strArray3[i].Length; j++)
                {
                    str2 = str2 + "," + strArray2[i] + strArray3[i].Substring(j, 1);
                }
            }
            return str2.Substring(1);
        }

        public static DataView GetUserData(long userId)
        {
            User user = GetUser(userId.ToString());
            if (user == null)
            {
                throw ExceptionManager.Instance.CreateException("TianWen0100600019", new object[] { userId });
            }
            return GetUserData(user.LogonID, user.OrganiseID);
        }

        public static DataView GetUserData(string loginId)
        {
            return GetUserData(loginId, string.Empty);
        }

        public static DataView GetUserData(string loginId, string orgId)
        {
            return iuserDao_0.GetUserData(loginId, orgId);
        }

        public static UserView GetUserView(string UserId)
        {
            return iuserDao_0.GetUserView(UserId);
        }

        public static bool HasRight(string rightType, string rightId, string userId)
        {
            return iuserDao_0.HasRight(rightType, rightId, userId, "");
        }

        public static bool HasRight(string rightType, string rightId, string rightValue, string userId)
        {
            return iuserDao_0.HasRight(rightType, rightId, userId, rightValue);
        }

        public static bool UserIsDeptHeader(string userId)
        {
            return iuserDao_0.UserIsDeptHeader(userId);
        }
    }
}

