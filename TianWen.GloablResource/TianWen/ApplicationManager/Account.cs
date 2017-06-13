namespace TianWen.ApplicationManager
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [Serializable]
    public class Account
    {
        public string DeptId;
        public string DeptName;
        public string Duty;
        public string EncPassword;
        public string Grade;
        public string IdentityCard;
        public string IdentityKey;
        public string Ip;
        public bool IsDeptHeader;
        public string LoginId;
        public string OrgFullName;
        public string OrgId;
        public string OrgName;
        public Account[] PartTimeUser;
        public string Password;
        public string UserAllRight;
        public string UserId;
        public string UserName;

        public Account()
        {
            this.PartTimeUser = new Account[0];
        }

        public Account(string loginId, string password, string userName, string deptId, string orgId, string userId, string deptName, string orgName, string grade, string duty, string encPassword, bool isDeptHeader, string orgFullName, string userAllRight, string identityCard, string identityKey, string string_0 = null)
        {
            this.PartTimeUser = new Account[0];
            this.LoginId = loginId;
            this.Password = password;
            this.UserName = userName;
            this.DeptId = deptId;
            this.OrgId = orgId;
            this.UserId = userId;
            this.DeptName = deptName;
            this.OrgName = orgName;
            this.Grade = grade;
            this.Duty = duty;
            this.EncPassword = encPassword;
            this.IsDeptHeader = isDeptHeader;
            this.OrgFullName = orgFullName;
            this.UserAllRight = "," + userAllRight + ",";
            this.IdentityCard = identityCard;
            this.IdentityKey = identityKey;
            this.Ip = string_0;
        }

        public IDictionary<string, object> CreateNameValueList()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(14);
            dictionary.Add("LoginId", this.LoginId);
            dictionary.Add("Password", this.Password);
            dictionary.Add("UserName", this.UserName);
            dictionary.Add("DeptId", this.DeptId);
            dictionary.Add("OrgId", this.OrgId);
            dictionary.Add("UserId", this.UserId);
            dictionary.Add("DeptName", this.DeptName);
            dictionary.Add("OrgName", this.OrgName);
            dictionary.Add("Grade", this.Grade);
            dictionary.Add("Duty", this.Duty);
            dictionary.Add("EncPassword", this.EncPassword);
            dictionary.Add("IsDeptHeader", this.IsDeptHeader);
            dictionary.Add("OrgFullName", this.OrgFullName);
            dictionary.Add("UserAllRight", this.UserAllRight);
            dictionary.Add("Ip", this.Ip);
            return dictionary;
        }

        public bool HasRight(string rightType, string rightId)
        {
            return this.HasRight(rightType, rightId, "R");
        }

        public bool HasRight(string rightType, string rightId, string rightValue)
        {
            string str = "," + rightType + rightId + rightValue + ",";
            return (this.UserAllRight.IndexOf(str) != -1);
        }
    }
}

