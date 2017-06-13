namespace TianWen.Utility.SystemManager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IGroupDao : ITianWenComponent
    {
        void AddGroup(NameValueCollection data);
        void AddGroupMember(IList<NameValueCollection> list);
        void AddGroupMember(NameValueCollection data);
        void AddGroupMember(string groupId, string userList);
        void DeleteGroup(string groupId);
        void DeleteGroupMember(string ID);
        bool ExistsGroupName(string groupId, string name);
        DataTable GetGroupMembers(string groupId);
        DataTable GetGroups(string searchExpress, string userId = "");
        void ModifyGroup(NameValueCollection data);
    }
}

