using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_CJYBLL : IBaseBLL
    {
        object SaveLYJD_CJYJBXX(JCXX jcxx, LYJD_CJYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_CJYJBXX(string LYJD_CJYJBXXID);
    }
}
