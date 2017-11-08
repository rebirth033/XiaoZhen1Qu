using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_HPGBLL : IBaseBLL
    {
        object SaveXXYL_HPGJBXX(JCXX jcxx, XXYL_HPGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_HPGJBXX(string ID);
    }
}
