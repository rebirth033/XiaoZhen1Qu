using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJCCXBLL : IBaseBLL
    {
        object LoadZXJCXX(string TYPE, string Condition, string PageIndex, string PageSize);

        object LoadZXJCXX(string TYPE, string ID);
    }
}
