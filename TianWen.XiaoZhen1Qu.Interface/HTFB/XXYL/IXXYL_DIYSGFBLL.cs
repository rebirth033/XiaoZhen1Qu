using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_DIYSGFBLL : IBaseBLL
    {
        object SaveXXYL_DIYSGFJBXX(JCXX jcxx, XXYL_DIYSGFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_DIYSGFJBXX(string ID);
    }
}
