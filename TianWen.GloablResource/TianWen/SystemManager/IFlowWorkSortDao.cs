namespace TianWen.SystemManager
{
    using System;
    using System.Data;
    using TianWen.Plus4MEF;

    public interface IFlowWorkSortDao : ITianWenComponent
    {
        DataView GetUserOwnedApps(string sWorkType, string appCode, string userId);
        DataView GetWorkUrl(string workType, string appCode, string userId);
        void InitialFlowWorkSort(string sWorkType, string userId);
        int Reset(string userId, string appCode, string sWorkType);
        bool Sort(string sWorkType, string appCode, string userId, string[] flowWorkdIds, string[] isValids);
    }
}

