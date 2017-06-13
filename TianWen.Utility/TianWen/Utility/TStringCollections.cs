namespace TianWen.Utility
{
    using System;
    using System.Collections.Specialized;

    public class TStringCollections
    {
        private StringCollection stringCollection_0 = null;
        private StringCollection stringCollection_1 = null;

        public string GetKey(int Index)
        {
            if (this.stringCollection_0 == null)
            {
                return "";
            }
            if ((Index < 0) || (Index >= this.stringCollection_0.Count))
            {
                return "";
            }
            return this.stringCollection_0[Index];
        }

        public string GetText(string Delimiter)
        {
            string str = "";
            string str2 = ",";
            if ((Delimiter != "") && (Delimiter != null))
            {
                str2 = Delimiter;
            }
            if (this.stringCollection_0 == null)
            {
                return "";
            }
            for (int i = 0; i < this.stringCollection_0.Count; i++)
            {
                str = str + this.stringCollection_0[i] + "=" + this.stringCollection_1[i] + str2;
            }
            if (str != "")
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public virtual string GetValues(int Index)
        {
            if (Index < 0)
            {
                return "";
            }
            return this.stringCollection_1[Index];
        }

        public virtual string GetValues(string Name)
        {
            int num = this.IndexOfName(Name);
            if (num < 0)
            {
                return "";
            }
            return this.stringCollection_1[num];
        }

        public int IndexOfName(string Name)
        {
            if (this.stringCollection_0 == null)
            {
                return -1;
            }
            return this.stringCollection_0.IndexOf(Name);
        }

        private int method_0()
        {
            if (this.stringCollection_0 == null)
            {
                return 0;
            }
            return this.stringCollection_0.Count;
        }

        public void Remove(string Name)
        {
            if (this.stringCollection_0 != null)
            {
                int index = this.IndexOfName(Name);
                if (index >= 0)
                {
                    this.stringCollection_0.RemoveAt(index);
                    this.stringCollection_1.RemoveAt(index);
                }
            }
        }

        public void SetValues(string Name, string Value)
        {
            int num = this.IndexOfName(Name);
            if (this.stringCollection_0 == null)
            {
                this.stringCollection_0 = new StringCollection();
            }
            if (this.stringCollection_1 == null)
            {
                this.stringCollection_1 = new StringCollection();
            }
            if (num < 0)
            {
                this.stringCollection_0.Add(Name);
                this.stringCollection_1.Add(Value);
            }
            else
            {
                this.stringCollection_1[num] = Value;
            }
        }

        public int Count
        {
            get
            {
                return this.method_0();
            }
        }

        public StringCollection Names
        {
            get
            {
                return this.stringCollection_0;
            }
            set
            {
                this.stringCollection_0 = value;
            }
        }

        public StringCollection Values
        {
            get
            {
                return this.stringCollection_1;
            }
            set
            {
                this.stringCollection_1 = value;
            }
        }
    }
}

