using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_GNYBLL : IBaseBLL
    {
        object SaveLYJD_GNYJBXX(JCXX jcxx, LYJD_GNYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_GNYJBXX(string ID);
    }
}
