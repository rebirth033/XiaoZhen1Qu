using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_QPZYBLL : IBaseBLL
    {
        object SaveXXYL_QPZYJBXX(JCXX jcxx, XXYL_QPZYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_QPZYJBXX(string XXYL_QPZYJBXXID);
    }
}
