namespace TianWen.GlobalResource
{
    using System;

    [Serializable]
    public class UserView
    {
        private string _deptid;
        private string _deptname;
        private string _logonid;
        private string _orgid;
        private string _orgname;
        private string _password;
        private string _userid;
        private string _username;

        public string deptid
        {
            get
            {
                return this._deptid;
            }
            set
            {
                this._deptid = value;
            }
        }

        public string deptname
        {
            get
            {
                return this._deptname;
            }
            set
            {
                this._deptname = value;
            }
        }

        public string logonid
        {
            get
            {
                return this._logonid;
            }
            set
            {
                this._logonid = value;
            }
        }

        public string orgid
        {
            get
            {
                return this._orgid;
            }
            set
            {
                this._orgid = value;
            }
        }

        public string orgname
        {
            get
            {
                return this._orgname;
            }
            set
            {
                this._orgname = value;
            }
        }

        public string password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string userid
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }

        public string username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }
    }
}

