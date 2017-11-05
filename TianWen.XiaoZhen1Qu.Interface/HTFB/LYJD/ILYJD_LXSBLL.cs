using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_LXSBLL : IBaseBLL
    {
        object SaveLYJD_LXSJBXX(JCXX jcxx, LYJD_LXSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_LXSJBXX(string LYJD_LXSJBXXID);
    }
}
