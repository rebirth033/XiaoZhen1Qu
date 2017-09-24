using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICW_CWMBLL : IBaseBLL
    {
        object SaveCW_CWMJBXX(JCXX jcxx, CW_CWMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWMJBXX(string CW_CWMJBXXID);
    }
}
