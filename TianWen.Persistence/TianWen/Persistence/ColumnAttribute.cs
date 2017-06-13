namespace TianWen.Persistence
{
    using System;

    [Serializable, AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
    public class ColumnAttribute : Attribute
    {
        private string _AliasName;
        private string _check;
        private ColumnType _DataType;
        private int _length;
        private bool _notnull;
        private readonly int _position;
        private int _scale;
        private string _SourceName;
        private bool _unique;
        private string _uniquekey;

        public ColumnAttribute() : this(0)
        {
        }

        public ColumnAttribute(int position)
        {
            this._length = -1;
            this._position = position;
        }

        public virtual string AliasName
        {
            get
            {
                return this._AliasName;
            }
            set
            {
                this._AliasName = value;
            }
        }

        public virtual string Check
        {
            get
            {
                return this._check;
            }
            set
            {
                this._check = value;
            }
        }

        public virtual ColumnType DataType
        {
            get
            {
                return this._DataType;
            }
            set
            {
                this._DataType = value;
            }
        }

        public virtual int Length
        {
            get
            {
                return this._length;
            }
            set
            {
                this._length = value;
            }
        }

        public virtual bool NotNull
        {
            get
            {
                return this._notnull;
            }
            set
            {
                this._notnull = value;
            }
        }

        public int Position
        {
            get
            {
                return this._position;
            }
        }

        public virtual int Scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
            }
        }

        public virtual string SourceName
        {
            get
            {
                return this._SourceName;
            }
            set
            {
                this._SourceName = value;
            }
        }

        public virtual bool Unique
        {
            get
            {
                return this._unique;
            }
            set
            {
                this._unique = value;
            }
        }

        public virtual string UniqueKey
        {
            get
            {
                return this._uniquekey;
            }
            set
            {
                this._uniquekey = value;
            }
        }
    }
}

