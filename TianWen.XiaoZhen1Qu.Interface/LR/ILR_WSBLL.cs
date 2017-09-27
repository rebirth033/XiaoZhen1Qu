using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_WSBLL : IBaseBLL
    {
        object SaveLR_WSJBXX(JCXX jcxx, LR_WSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_WSJBXX(string LR_WSJBXXID);
    }
}
