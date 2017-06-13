namespace TianWen.Logger.LowestLog
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using TianWen.Logger;

    internal class Class25 : ILog
    {
        private static readonly IList<Class26> ilist_0 = new List<Class26>(int_0);
        private static readonly int int_0 = 10;
        private readonly int int_1;
        private readonly string string_0;
        private readonly Thread thread_0;

        public Class25(string string_1, int int_2 = 0x1388)
        {
            this.string_0 = string_1;
            this.int_1 = int_2;
            this.thread_0 = new Thread(new ThreadStart(this.method_1));
            this.thread_0.Start();
        }

        public void method_0()
        {
            if (ilist_0.Count > 0)
            {
                lock (ilist_0)
                {
                    if (ilist_0.Count > 0)
                    {
                        this.method_2();
                    }
                }
            }
        }

        private void method_1()
        {
            while (true)
            {
                this.method_0();
                Thread.Sleep(this.int_1);
            }
        }

        private void method_2()
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(this.string_0, File.Exists(this.string_0) ? FileMode.Append : FileMode.CreateNew), Encoding.UTF8))
            {
                Class26[] array = new Class26[ilist_0.Count];
                ilist_0.CopyTo(array, 0);
                ilist_0.Clear();
                foreach (Class26 class2 in array)
                {
                    writer.WriteLine(class2.ToString());
                }
                writer.Flush();
                writer.Close();
            }
        }

        private static void smethod_0(Class26 class26_0)
        {
            lock (ilist_0)
            {
                ilist_0.Add(class26_0);
            }
        }

        void ILog.Debug(object Msg)
        {
            smethod_0(new Class26(Enum0.const_0, Msg, null));
        }

        void ILog.Debug(object Msg, Exception exception)
        {
            smethod_0(new Class26(Enum0.const_0, Msg, exception));
        }

        void ILog.Error(object Msg)
        {
            smethod_0(new Class26(Enum0.const_1, Msg, null));
        }

        void ILog.Error(object Msg, Exception exception)
        {
            smethod_0(new Class26(Enum0.const_1, Msg, exception));
        }

        void ILog.Fatal(object Msg)
        {
            smethod_0(new Class26(Enum0.const_2, Msg, null));
        }

        void ILog.Fatal(object Msg, Exception exception)
        {
            smethod_0(new Class26(Enum0.const_2, Msg, exception));
        }

        void ILog.Info(object Msg)
        {
            smethod_0(new Class26(Enum0.const_3, Msg, null));
        }

        void ILog.Info(object Msg, Exception exception)
        {
            smethod_0(new Class26(Enum0.const_3, Msg, exception));
        }

        void ILog.Warn(object Msg)
        {
            smethod_0(new Class26(Enum0.const_4, Msg, null));
        }

        void ILog.Warn(object Msg, Exception exception)
        {
            smethod_0(new Class26(Enum0.const_4, Msg, exception));
        }

        internal class Class26
        {
            [CompilerGenerated]
            private Class25.Enum0 enum0_0;
            [CompilerGenerated]
            private Exception exception_0;
            [CompilerGenerated]
            private string string_0;

            public Class26(Class25.Enum0 enum0_1, object object_0, Exception exception_1 = null)
            {
                this.method_1(enum0_1);
                this.method_3(object_0.ToString());
                this.method_5(exception_1);
            }

            [CompilerGenerated]
            public Class25.Enum0 method_0()
            {
                return this.enum0_0;
            }

            [CompilerGenerated]
            private void method_1(Class25.Enum0 enum0_1)
            {
                this.enum0_0 = enum0_1;
            }

            [CompilerGenerated]
            public string method_2()
            {
                return this.string_0;
            }

            [CompilerGenerated]
            private void method_3(string value)
            {
                this.string_0 = value;
            }

            [CompilerGenerated]
            public Exception method_4()
            {
                return this.exception_0;
            }

            [CompilerGenerated]
            private void method_5(Exception exception_1)
            {
                this.exception_0 = exception_1;
            }

            public override string ToString()
            {
                string str = string.Format("{0} : 类型[{1}]\t消息: {2}", DateTime.Now, this.method_0(), this.method_2());
                if (this.method_4() != null)
                {
                    str = str + string.Format(" \r\n异常明细:\r\n{0}\r\n", this.method_4());
                }
                return str;
            }
        }

        internal enum Enum0
        {
            const_0,
            const_1,
            const_2,
            const_3,
            const_4
        }
    }
}

