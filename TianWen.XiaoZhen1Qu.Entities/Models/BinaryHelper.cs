using System;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public static class BinaryHelper
    {
        /// <summary>
        /// 将字符串转成二进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] StringToBinary(string s)
        {
            byte[] data = Encoding.Unicode.GetBytes(s);
            return data;
        }

        /// <summary>
        /// 将二进制转成字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string BinaryToString(byte[] data)
        {
            if (data == null) return string.Empty;
            return Encoding.Unicode.GetString(data, 0, data.Length);
        }
    }
}
