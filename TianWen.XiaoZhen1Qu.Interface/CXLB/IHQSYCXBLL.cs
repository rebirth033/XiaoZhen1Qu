using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSYCXBLL : IBaseBLL
    {
        object LoadHQSYXX(string TYPE, string Condition, string PageIndex, string PageSize);

        object LoadHQSYXX(string TYPE, string ID);
    }
}
