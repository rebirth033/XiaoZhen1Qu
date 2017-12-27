using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFWCXBLL : IBaseBLL
    {
        object LoadSWFWXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType);

        object LoadSWFWXX(string TYPE, string ID);
    }
}
