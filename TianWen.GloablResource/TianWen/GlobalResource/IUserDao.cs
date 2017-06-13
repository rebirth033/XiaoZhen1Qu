using TianWen.SystemManager.Model;

namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.WebForm.Controls;

    public interface IUserDao : IDivTreeDataReader
    {
        void AddUser(NameValueCollection rowData);
        DataView BindUserList(string deptId = "", string dbName = "Defatul");
        void DeleteUserByID(string ID);
        void DisableUserDept(string userId);
        bool ExistsLoginID(string userID, string value);
        IList<User> GetAllUser(bool hasRight);
        IList<UserView> GetAllUserView();
        IList<string> GetFlowRight(string UserId, string FlowId, string StepId);
        IList<RightControl> GetRightControlByUserId(string UserId);
        NameValueCollection GetUserAccountBySessionId(string sessionId);
        DataView GetUserAllRightData(string userId);
        DataView GetUserAllRightData(string userId, string appCode);
        IList<UserRight> GetUserAllRightList(string userId);
        User GetUserById(string UserId);
        User GetUserByLogId(string LogId, string OrgId);
        DataView GetUserData(string loginId, string orgId);
        NameValueCollection GetUserInfoByUserId(string userId);
        DataTable GetUserMultiDeptByUserId(string userId);
        DataTable GetUserMultiDeptIsEnabledByUserId(string userId, string status);
        IList<UserRight> GetUserRightByUserId(string UserId);
        DataTable GetUserRightTableByUserId(string UserId);
        IList<User> GetUsers(string deptID = "0", string searchExpression = "");
        IList<User> GetUsersByDeptId(string deptId);
        IList<User> GetUsersByOrgId(string orgId);
        IList<User> GetUsersIsEnabledByDeptId(string deptId, string status);
        IList<User> GetUsersIsEnabledByOrgId(string orgId, string status);
        DataView GetUserTree(string deptId);
        UserView GetUserView(string UserId);
        bool HasRight(string rightType, string rightId, string userId, string rightValue = "");
        bool InitPassword(string loginID);
        void ModifyUser(NameValueCollection rowData);
        void NewUser(NameValueCollection data);
        void SetUserRight(string userId, IEnumerable<RoleRight> userRights, string removeList, string dbName = "Default");
        bool UserIsDeptHeader(string userId);
        void WriteSiginLog(string userId, string userName, string string_0, string sessionId);
        void WriteSigoutLog(string userId, string sessionId);
    }
}

