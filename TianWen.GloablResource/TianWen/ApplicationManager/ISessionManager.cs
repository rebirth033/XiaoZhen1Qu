namespace TianWen.ApplicationManager
{
    using System;
    using TianWen.Plus4MEF;

    public interface ISessionManager : ITianWenComponent
    {
        void ClearSession();
        bool ContainsAccount(string sessionId);
        Account GetAccount(string sessionId);
        bool HasSignIned(string loginId, string orgId);
        Account RefreshAccount(string sessionId);
        Account SignIn(string userId, string password, string sessionId);
        Account SignIn(string loginId, string password, string orgId, string sessionId);
        Account SignIn(string loginId, string password, string orgId, string sessionId, string authenticateType);
        void SignOut(string sessionId);
        void UpdateAccount(string sessionId, Account newAccount);
    }
}

