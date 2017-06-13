namespace TianWen.Persistence
{
    using System;
    using System.Collections;
    using System.Data;

    internal class Class2
    {
        private readonly Hashtable hashtable_0 = Hashtable.Synchronized(new Hashtable());

        public void method_0()
        {
            this.hashtable_0.Clear();
        }

        public void method_1(string string_0, IDbCommand idbCommand_0, IDataParameter[] idataParameter_0)
        {
            string commandText = idbCommand_0.CommandText;
            string str2 = smethod_1(string_0, commandText);
            this.hashtable_0[str2] = idataParameter_0;
        }

        public IDataParameter[] method_2(string string_0, IDbCommand idbCommand_0)
        {
            string commandText = idbCommand_0.CommandText;
            string str2 = smethod_1(string_0, commandText);
            IDataParameter[] parameterArray = (IDataParameter[]) this.hashtable_0[str2];
            return smethod_0(parameterArray);
        }

        public bool method_3(string string_0, IDbCommand idbCommand_0)
        {
            string str = smethod_1(string_0, idbCommand_0.CommandText);
            return (this.hashtable_0[str] != null);
        }

        public static IDataParameter[] smethod_0(IDataParameter[] idataParameter_0)
        {
            IDataParameter[] parameterArray = new IDataParameter[idataParameter_0.Length];
            int index = 0;
            int length = idataParameter_0.Length;
            while (index < length)
            {
                parameterArray[index] = (IDataParameter) ((ICloneable) idataParameter_0[index]).Clone();
                index++;
            }
            return parameterArray;
        }

        private static string smethod_1(string string_0, string string_1)
        {
            return (string_0 + ":" + string_1);
        }
    }
}

