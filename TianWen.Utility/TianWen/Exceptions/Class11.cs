namespace TianWen.Exceptions
{
    using System;
    using System.IO;
    using TianWen.Logger;

    internal class Class11 : IModule
    {
        private void method_0(string Msg)
        {
            string path = TianWen.Exceptions.Settings.LogPath + @"\" + DateTime.Now.ToString("yyyyMM") + @"\" + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream stream = new FileStream(path + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.BaseStream.Seek(0L, SeekOrigin.End);
                writer.WriteLine(writer.NewLine + Msg);
                writer.Flush();
                writer.Close();
                stream.Close();
            }
        }

        private string method_1(TianWenException TianWenException_0)
        {
            object obj2 = ((("" + "[时间]：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n") + "[错误代码]：" + TianWenException_0.Code + "\r\n") + "[错误信息]：" + TianWenException_0.Message + "\r\n") + "[错误对象的应用程序或者对象]：" + TianWenException_0.Source + "\r\n";
            obj2 = string.Concat(new object[] { obj2, "[错误异常的实例]：", TianWenException_0.InnerException, "\r\n" });
            return (string.Concat(new object[] { obj2, "[引发当前异常的方法]：", TianWenException_0.TargetSite, "\r\n" }) + "[堆栈信息]：\r\n" + TianWenException_0.TianWenStackTrace + "\r\n");
        }

        public void Run(TianWenException TianWenException)
        {
            if (TianWen.Exceptions.Settings.IsWriteLog)
            {
                TianWenMessage msg = new TianWenMessage("系统", "记录日志", "01", TianWenException.Message);
                LoggerManager.Error(msg, TianWenException);
            }
        }
    }
}

