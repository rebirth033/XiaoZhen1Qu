using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCGCXBLL : IBaseBLL
    {
        object LoadPFCGXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType, string XZQDM);

        object LoadPFCGXX(string TYPE, string ID);
    }
}
