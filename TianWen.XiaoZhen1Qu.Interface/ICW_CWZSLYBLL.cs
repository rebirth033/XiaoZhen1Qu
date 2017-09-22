using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICW_CWZSLYBLL : IBaseBLL
    {
        object SaveCW_CWZSLYJBXX(JCXX jcxx, CW_CWZSLYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWZSLYJBXX(string CW_CWZSLYJBXXID);
    }
}
