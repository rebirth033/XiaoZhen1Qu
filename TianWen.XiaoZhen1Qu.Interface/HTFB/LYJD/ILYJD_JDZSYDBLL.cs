using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_JDZSYDBLL : IBaseBLL
    {
        object SaveLYJD_JDZSYDJBXX(JCXX jcxx, LYJD_JDZSYDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_JDZSYDJBXX(string LYJD_JDZSYDJBXXID);
    }
}
