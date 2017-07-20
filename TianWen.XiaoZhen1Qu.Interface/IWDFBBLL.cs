using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IWDFBBLL
    {
        IDAO DAO { get; set; }

        object LoadZXXX(string YHID);
    }
}
