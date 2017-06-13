namespace TianWen.GlobalResource
{
    using System;

    [Serializable]
    public class SystemRight
    {
        private string _DefaultRight;
        private string _RightID;
        private string _RightName;
        private string _RightType;
        private string _RightValue;
        private string _SuperRightID;

        public string DefaultRight
        {
            get
            {
                return this._DefaultRight;
            }
            set
            {
                this._DefaultRight = value;
            }
        }

        public string RightID
        {
            get
            {
                return this._RightID;
            }
            set
            {
                this._RightID = value;
            }
        }

        public string RightName
        {
            get
            {
                return this._RightName;
            }
            set
            {
                this._RightName = value;
            }
        }

        public string RightType
        {
            get
            {
                return this._RightType;
            }
            set
            {
                this._RightType = value;
            }
        }

        public string RightValue
        {
            get
            {
                return this._RightValue;
            }
            set
            {
                this._RightValue = value;
            }
        }

        public string SuperRightID
        {
            get
            {
                return this._SuperRightID;
            }
            set
            {
                this._SuperRightID = value;
            }
        }
    }
}

