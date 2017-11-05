using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_DYDDRBLL : IBaseBLL
    {
        object SaveLYJD_DYDDRJBXX(JCXX jcxx, LYJD_DYDDRJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_DYDDRJBXX(string LYJD_DYDDRJBXXID);
    }
}
