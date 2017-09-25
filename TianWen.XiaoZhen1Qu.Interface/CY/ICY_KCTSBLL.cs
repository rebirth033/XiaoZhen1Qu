using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICY_KCTSBLL : IBaseBLL
    {
        object SaveCY_KCTSJBXX(JCXX jcxx, CY_KCTSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCY_KCTSJBXX(string CY_KCTSJBXXID);
    }
}
