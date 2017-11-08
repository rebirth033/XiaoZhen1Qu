using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICW_CWGBLL : IBaseBLL
    {
        object SaveCW_CWGJBXX(JCXX jcxx, CW_CWGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWGJBXX(string ID);
    }
}
