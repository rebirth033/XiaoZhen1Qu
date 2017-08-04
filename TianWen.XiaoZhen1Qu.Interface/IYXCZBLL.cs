using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IYXCZBLL
    {
        IDAO DAO { get; set; }

        object LoadYXJBXX(string YHID, string SZM);
    }
}
