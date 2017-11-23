using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJDCXBLL : IBaseBLL
    {
        object LoadLYJDXX(string TYPE, string Condition, string PageIndex, string PageSize);

        object LoadLYJDXX(string TYPE, string ID);
    }
}
