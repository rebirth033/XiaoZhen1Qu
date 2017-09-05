using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IWDFBBLL:IBaseBLL
    {
        IDAO DAO { get; set; }

        object LoadYHFBXX(string YHID, string TYPE, string PageIndex, string PageSize);

        object UpdateYHFBXX(string JCXXID, string OPTYPE);
    }
}
