using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IWDXJBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object LoadSZMX(string YHID, string LX, string ZJLX, string StartTime, string EndTime, string PageIndex, string PageSize);

        object LoadDJJDJL(string YHID, string LX, string StartTime, string EndTime, string PageIndex, string PageSize);
    }
}
