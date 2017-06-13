namespace TianWen.SystemManager.Interface
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using TianWen.Plus4MEF;

    public interface IUserDepartment : ITianWenComponent
    {
        void DeleteUserDepartment(string udid);
        DataTable GetUserDeparment();
        void SaveUserDepartment(NameValueCollection data);
    }
}

