using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILRCXBLL : IBaseBLL
    {
        object LoadLRXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType, string XZQDM);

        object LoadLRXX(string TYPE, string ID);
    }
}
