namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class User
    {
        private string _Addr;
        private string _DeptAbbr;
        private string _DeptID;
        private string _Duty;
        private string _EMail;
        private string _EntryTime;
        private string _HouseTel;
        private string _IDCD;
        private string _identityKey;
        private string _IP;
        private string _IP2;
        private string _LogonID;
        private string _Mobile;
        private string _NetAcl;
        private string _OICQ;
        private string _OrderNO;
        private string _OrganiseID;
        private string _PassWord;
        private string _PostCode;
        private string _QQ;
        private string _Room;
        private string _Sex;
        private string _Status;
        private object _StatusTime;
        private string _SuperID;
        private string _Tel;
        private string _Title;
        private string _UserCode;
        private string _UserID;
        private string _UserName;
        public Collection<UserRight> Rights = new Collection<UserRight>();

        public override bool Equals(object object_0)
        {
            User user = (User) object_0;
            return (this.UserID.Equals(user.UserID) && this.DeptID.Equals(user.DeptID));
        }

        public override int GetHashCode()
        {
            return (this.UserID.GetHashCode() ^ this.DeptID.GetHashCode());
        }

        public string Addr
        {
            get
            {
                return this._Addr;
            }
            set
            {
                this._Addr = value;
            }
        }

        public string DeptAbbr { get; set; }

        public string DeptID
        {
            get
            {
                return this._DeptID;
            }
            set
            {
                this._DeptID = value;
            }
        }

        public string Duty
        {
            get
            {
                return this._Duty;
            }
            set
            {
                this._Duty = value;
            }
        }

        public string EMail
        {
            get
            {
                return this._EMail;
            }
            set
            {
                this._EMail = value;
            }
        }

        public string EntryTime
        {
            get
            {
                return this._EntryTime;
            }
            set
            {
                this._EntryTime = value;
            }
        }

        public string HouseTel
        {
            get
            {
                return this._HouseTel;
            }
            set
            {
                this._HouseTel = value;
            }
        }

        public string IDCD
        {
            get
            {
                return this._IDCD;
            }
            set
            {
                this._IDCD = value;
            }
        }

        public string identityKey
        {
            get
            {
                return this._identityKey;
            }
            set
            {
                this._identityKey = value;
            }
        }

        public string IP
        {
            get
            {
                return this._IP;
            }
            set
            {
                this._IP = value;
            }
        }

        public string IP2
        {
            get
            {
                return this._IP2;
            }
            set
            {
                this._IP2 = value;
            }
        }

        public string LogonID
        {
            get
            {
                return this._LogonID;
            }
            set
            {
                this._LogonID = value;
            }
        }

        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                this._Mobile = value;
            }
        }

        public string NetAcl
        {
            get
            {
                return this._NetAcl;
            }
            set
            {
                this._NetAcl = value;
            }
        }

        public string OICQ
        {
            get
            {
                return this._OICQ;
            }
            set
            {
                this._OICQ = value;
            }
        }

        public string OrderNO
        {
            get
            {
                return this._OrderNO;
            }
            set
            {
                this._OrderNO = value;
            }
        }

        public string OrganiseID
        {
            get
            {
                return this._OrganiseID;
            }
            set
            {
                this._OrganiseID = value;
            }
        }

        public string OwnerId { get; set; }

        public string PassWord
        {
            get
            {
                return this._PassWord;
            }
            set
            {
                this._PassWord = value;
            }
        }

        public string PostCode
        {
            get
            {
                return this._PostCode;
            }
            set
            {
                this._PostCode = value;
            }
        }

        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {
                this._QQ = value;
            }
        }

        public string Room
        {
            get
            {
                return this._Room;
            }
            set
            {
                this._Room = value;
            }
        }

        public string Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                this._Sex = value;
            }
        }

        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }

        public object StatusTime
        {
            get
            {
                return this._StatusTime;
            }
            set
            {
                this._StatusTime = value;
            }
        }

        public string SuperID
        {
            get
            {
                return this._SuperID;
            }
            set
            {
                this._SuperID = value;
            }
        }

        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                this._Tel = value;
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }

        public string UserCode
        {
            get
            {
                return this._UserCode;
            }
            set
            {
                this._UserCode = value;
            }
        }

        public string UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }
    }
}

