using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_HWBLL : IBaseBLL
    {
        object SaveXXYL_HWJBXX(JCXX jcxx, XXYL_HWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_HWJBXX(string ID);
    }
}
