namespace TianWen.Utility
{
    using System;
    using System.Collections.Specialized;

    public class TStrings
    {
        private char char_0 = ',';
        private string string_0 = "";
        private StringCollection stringCollection_0 = null;
        private StringCollection stringCollection_1 = null;

        public int GetCount()
        {
            if (this.stringCollection_0 == null)
            {
                return 0;
            }
            return this.stringCollection_0.Count;
        }

        public string GetDelimiterText()
        {
            string str = "";
            for (int i = 0; i < this.stringCollection_0.Count; i++)
            {
                str = string.Concat(new object[] { str, "\"", this.stringCollection_0[i], "=", this.stringCollection_1[i], "\"", this.char_0 });
            }
            if (str != "")
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        public string GetName(int Index)
        {
            if (Index < 0)
            {
                return "";
            }
            return this.stringCollection_0[Index];
        }

        public int IndexOfName(string Name)
        {
            if (this.stringCollection_0 == null)
            {
                return -1;
            }
            return this.stringCollection_0.IndexOf(Name);
        }

        private void method_0(string value)
        {
            this.string_0 = value;
            this.stringCollection_0 = null;
            this.stringCollection_1 = null;
            if ((this.string_0 != null) && !(this.string_0 == ""))
            {
                this.stringCollection_0 = new StringCollection();
                this.stringCollection_1 = new StringCollection();
                string[] strArray = this.string_0.Split(new char[] { this.char_0 });
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { '=' }, 2);
                    this.stringCollection_0.Add(strArray2[0]);
                    if (strArray2.Length > 1)
                    {
                        this.stringCollection_1.Add(strArray2[1]);
                    }
                    else
                    {
                        this.stringCollection_1.Add("");
                    }
                }
            }
        }

        private string method_1()
        {
            string str = "";
            for (int i = 0; i < this.stringCollection_0.Count; i++)
            {
                str = string.Concat(new object[] { str, this.stringCollection_0[i], "=", this.stringCollection_1[i], this.char_0 });
            }
            if (str != "")
            {
                str = str.Substring(0, str.Length - 1);
            }
            this.string_0 = str;
            return str;
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

        public virtual string Values(int Index)
        {
            if (Index < 0)
            {
                return "";
            }
            return this.stringCollection_1[Index];
        }

        public virtual string Values(string Name)
        {
            int num = this.IndexOfName(Name);
            if (num < 0)
            {
                return "";
            }
            return this.stringCollection_1[num];
        }

        public int Count
        {
            get
            {
                return this.GetCount();
            }
        }

        public char Delimiter
        {
            get
            {
                return this.char_0;
            }
            set
            {
                this.char_0 = value;
            }
        }

        public string Text
        {
            get
            {
                return this.method_1();
            }
            set
            {
                this.method_0(value);
            }
        }
    }
}

