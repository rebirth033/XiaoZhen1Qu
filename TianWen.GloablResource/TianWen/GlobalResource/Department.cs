namespace TianWen.GlobalResource
{
    using System;
    using System.Collections.ObjectModel;

    [Serializable]
    public class Department
    {
        private string _Abbr;
        private string _ChiefID;
        private string _DeptID;
        private string _DeptKind;
        private string _DeptName;
        private string _Fax;
        private string _GroupName;
        private string _LeaderID;
        private string _OrderNO;
        private string _OrganiseID;
        private string _Remark;
        private string _Status;
        private object _StatusTime;
        private string _SuperDept;
        private string _Tel;
        public Collection<Department> Childs = new Collection<Department>();
        public Collection<User> Users = new Collection<User>();

        public override bool Equals(object object_0)
        {
            Department department = (Department) object_0;
            return (this.DeptID.Equals(department.DeptID) && this.OrganiseID.Equals(department.OrganiseID));
        }

        public override int GetHashCode()
        {
            return (this.OrganiseID.GetHashCode() ^ this.DeptID.GetHashCode());
        }

        public string Abbr
        {
            get
            {
                return this._Abbr;
            }
            set
            {
                this._Abbr = value;
            }
        }

        public string ChiefID
        {
            get
            {
                return this._ChiefID;
            }
            set
            {
                this._ChiefID = value;
            }
        }

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

        public string DeptKind
        {
            get
            {
                return this._DeptKind;
            }
            set
            {
                this._DeptKind = value;
            }
        }

        public string DeptName
        {
            get
            {
                return this._DeptName;
            }
            set
            {
                this._DeptName = value;
            }
        }

        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this._Fax = value;
            }
        }

        public string GroupName
        {
            get
            {
                return this._GroupName;
            }
            set
            {
                this._GroupName = value;
            }
        }

        public string LeaderID
        {
            get
            {
                return this._LeaderID;
            }
            set
            {
                this._LeaderID = value;
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

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
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

        public string SuperDept
        {
            get
            {
                return this._SuperDept;
            }
            set
            {
                this._SuperDept = value;
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
    }
}

