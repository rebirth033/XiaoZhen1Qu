using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_YDJSBLL : IBaseBLL
    {
        object SaveXXYL_YDJSJBXX(JCXX jcxx, XXYL_YDJSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_YDJSJBXX(string XXYL_YDJSJBXXID);
    }
}
