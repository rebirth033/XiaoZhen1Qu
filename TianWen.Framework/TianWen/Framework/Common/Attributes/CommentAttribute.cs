namespace TianWen.Framework.Common.Attributes
{
    using System;
    using System.Runtime.CompilerServices;

    public class CommentAttribute : Attribute
    {
        private bool _IsJump = false;
        private bool _IsKey = false;
        private bool _IsList = false;
        private bool _IsShow = false;

        public string ColName { get; set; }

        public string Description { get; set; }

        public bool IsJump
        {
            get
            {
                return this._IsJump;
            }
            set
            {
                this._IsJump = value;
            }
        }

        public bool IsKey
        {
            get
            {
                return this._IsKey;
            }
            set
            {
                this._IsKey = value;
            }
        }

        public bool IsList
        {
            get
            {
                return this._IsList;
            }
            set
            {
                this._IsList = value;
            }
        }

        public bool IsShow
        {
            get
            {
                return this._IsShow;
            }
            set
            {
                this._IsShow = value;
            }
        }
    }
}

