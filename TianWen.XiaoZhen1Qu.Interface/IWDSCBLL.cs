using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IWDSCBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object LoadSCXX(string YHID);

        object DeleteYHSCXX(string YHID, string JCXXID);
    }
}
