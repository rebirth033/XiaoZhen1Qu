using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICLCXBLL : IBaseBLL
    {
        object LoadCLXX(string TYPE, string Condition, string PageIndex, string PageSize);

        object LoadCLXX(string TYPE, string ID);
    }
}
