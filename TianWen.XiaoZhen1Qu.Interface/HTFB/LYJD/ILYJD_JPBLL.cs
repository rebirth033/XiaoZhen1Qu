using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_JPBLL : IBaseBLL
    {
        object SaveLYJD_JPJBXX(JCXX jcxx, LYJD_JPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_JPJBXX(string ID);
    }
}
