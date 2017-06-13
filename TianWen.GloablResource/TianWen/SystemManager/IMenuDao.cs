namespace TianWen.SystemManager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Runtime.InteropServices;
    using TianWen.Utility.GlobalResource.Portal;
    using TianWen.WebForm.Controls;

    public interface IMenuDao : IDivTreeDataReader
    {
        void AddMenu(NameValueCollection data);
        void DeleteMenu(string menuID);
        bool ExistsMenuName(string menuID, string ownerID, string name);
        MenuModel GetMenu(string menuID);
        IList<MenuModel> GetMenus(bool includeInvalid = false);
        IList<MenuModel> GetMenus(string parentID);
        DataTable GetMenus(string parentID = "0", int level = 0, bool includeInvalid = false);
        string GetMenuTitleById(int menuId);
        void ModifyMenu(NameValueCollection data);
    }
}

