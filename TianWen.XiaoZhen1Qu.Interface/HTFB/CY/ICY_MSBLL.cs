using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICY_MSBLL : IBaseBLL
    {
        object SaveCY_MSJBXX(JCXX jcxx, CY_MSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCY_MSJBXX(string ID);
    }
}
