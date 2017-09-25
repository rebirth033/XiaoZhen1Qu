using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_YDJBBLL : IBaseBLL
    {
        object SaveXXYL_YDJBJBXX(JCXX jcxx, XXYL_YDJBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadXXYL_YDJBJBXX(string XXYL_YDJBJBXXID);
    }
}
