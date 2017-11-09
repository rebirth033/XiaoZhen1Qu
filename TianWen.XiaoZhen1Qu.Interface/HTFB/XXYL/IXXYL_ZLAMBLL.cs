using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_ZLAMBLL : IBaseBLL
    {
        object SaveXXYL_ZLAMJBXX(JCXX jcxx, XXYL_ZLAMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_ZLAMJBXX(string ID);
    }
}
