using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFCCXBLL : IBaseBLL
    {
        object LoadFCXX(string TYPE, string Condition, string PageIndex, string PageSize, string XZQ);

        object LoadFCXX(string TYPE, string ID);
    }
}
