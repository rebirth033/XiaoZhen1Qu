using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface INLMFYCXBLL : IBaseBLL
    {
        object LoadNLMFYXX(string TYPE, string Condition, string PageIndex, string PageSize, string OrderColumn, string OrderType);

        object LoadNLMFYXX(string TYPE, string ID);
    }
}
