using TianWen.SystemManager.Model;

namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IRoleDao : ITianWenComponent
    {
        bool AddRoleMember(IList<NameValueCollection> list, string dbName = "");
        void AddRoleMember(string roleId, string userList);
        void AddRoleRight(NameValueCollection rowData, string dbName = "Default");
        void AddRoleRight(string roleId, IEnumerable<RoleRight> list, string removeList, string dbName = "Default");
        void AddRoleRight(string roleId, IList<NameValueCollection> list, string removeRoleList, string dbName = "");
        void AddRoles(NameValueCollection rowData, string dbName = "Default");
        bool CheckRoleNameIsExists(string roleName, int roleId, string dbName = "Default");
        DataTable DdlRolesForActors(string dbName = "Defatult");
        DataTable DdlRoleWorkPostList(string dbName = "Default");
        void DeleteRoleMember(string string_0, string dbName = "");
        void DeleteRoleRight(string string_0, string dbName = "");
        void DelRoles(string roleId, string dbName = "Default");
        void EditRoles(NameValueCollection rowData, string dbName = "Default");
        DataView GetAppResourceWithAppCodeAndRightType(string appCode, string roleid, string rightType = "*", string dbName = "Default");
        DataTable GetRoleMember(string roleId, string dbName = "");
        DataTable GetRoleRightList(string roleID, string dbName = "");
        DataTable GetRolesList(string dbName = "Default", string roleName = "", string searchExpression = "");
        DataTable GetRolesList(string dbName, string roleName, string searchExpression, string userId);
        DataView GetSystemrightWithRightType(string rightType, string dbName = "Default");
        DataTable InitRightTypeList(string appCode, string dbName = "Default");
    }
}

