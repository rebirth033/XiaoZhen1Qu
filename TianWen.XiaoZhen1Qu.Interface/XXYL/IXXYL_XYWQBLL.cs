using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_XYWQBLL : IBaseBLL
    {
        object SaveXXYL_XYWQJBXX(JCXX jcxx, XXYL_XYWQJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_XYWQJBXX(string XXYL_XYWQJBXXID);
    }
}
