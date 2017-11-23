using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYLCXBLL : IBaseBLL
    {
        object LoadXXYLXX(string TYPE, string Condition, string PageIndex, string PageSize);

        object LoadXXYLXX(string TYPE, string ID);
    }
}
