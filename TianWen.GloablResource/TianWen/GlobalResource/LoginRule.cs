namespace TianWen.GlobalResource
{
    using System;
    using System.Data;
    using TianWen.Persistence;

    public class LoginRule
    {
        private const string string_0 = "Select u.userid, u.deptid, o.OrganiseId, o.abbr OrgName, o.organisename, o.Grade, u.username, u.password, u.LogonID,d.Abbr DeptName, u.duty, u.sex, u.idcd, u.tel, u.room, u.addr, u.postcode, u.email, u.superid, u.orderno, u.mobile, u.housetel from users u,department d,Organise O where LogonID='{0}' and u.password='{1}' and u.Deptid=d.Deptid and o.OrganiseId=d.OrganiseId";
        private const string string_1 = "Select u.userid, u.deptid, o.OrganiseId, o.abbr OrgName, o.organisename, o.Grade, u.username, u.password, u.LogonID,d.Abbr DeptName, u.duty, u.sex, u.idcd, u.tel, u.room, u.addr, u.postcode, u.email, u.superid, u.orderno, u.mobile, u.housetel from users u,department d,Organise O where LogonID='{0}' and u.Deptid=d.Deptid and o.OrganiseId=d.OrganiseId";

        public DataSet GetUserAllRightData(string userId)
        {
            string commandText = "select GetUserRight(" + userId + ") allRight from dual ";
            return DbFactory.Instance.GetDbHelp("").GetDataSet(commandText, new IDataParameter[0]);
        }

        public DataSet GetUserData(string loginID, string password)
        {
            string commandText = string.Format("Select u.userid, u.deptid, o.OrganiseId, o.abbr OrgName, o.organisename, o.Grade, u.username, u.password, u.LogonID,d.Abbr DeptName, u.duty, u.sex, u.idcd, u.tel, u.room, u.addr, u.postcode, u.email, u.superid, u.orderno, u.mobile, u.housetel from users u,department d,Organise O where LogonID='{0}' and u.password='{1}' and u.Deptid=d.Deptid and o.OrganiseId=d.OrganiseId", loginID, password);
            return DbFactory.Instance.GetDbHelp("").GetDataSet(commandText, new IDataParameter[0]);
        }

        public DataSet GetUserDataById(string loginID)
        {
            string commandText = string.Format("Select u.userid, u.deptid, o.OrganiseId, o.abbr OrgName, o.organisename, o.Grade, u.username, u.password, u.LogonID,d.Abbr DeptName, u.duty, u.sex, u.idcd, u.tel, u.room, u.addr, u.postcode, u.email, u.superid, u.orderno, u.mobile, u.housetel from users u,department d,Organise O where LogonID='{0}' and u.Deptid=d.Deptid and o.OrganiseId=d.OrganiseId", loginID);
            return DbFactory.Instance.GetDbHelp("").GetDataSet(commandText, new IDataParameter[0]);
        }

        public bool UserIsDeptHeader(string userId)
        {
            string format = "select R.UserId from UserRight R where R.UserId='{0}' and R.RightType='R' and R.RightId='6' ";
            format = string.Format(format, userId);
            if (DbFactory.Instance.GetDbHelp("").ExecuteScalar(format) != null)
            {
                return true;
            }
            format = "select d.leaderid from users u, Department d where u.userid='{0}'  and u.deptid=d.deptid and d.leaderid=u.userid";
            format = string.Format(format, userId);
            return (DbFactory.Instance.GetDbHelp("").ExecuteScalar(format) != null);
        }
    }
}

