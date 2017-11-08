using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_TQTBLL : IBaseBLL
    {
        object SaveXXYL_TQTJBXX(JCXX jcxx, XXYL_TQTJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_TQTJBXX(string ID);
    }
}
