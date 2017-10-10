using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_YSPXJSBLL : IBaseBLL
    {
        object SaveJYPX_YSPXJSJBXX(JCXX jcxx, JYPX_YSPXJSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YSPXJSJBXX(string JYPX_YSPXJSJBXXID);
    }
}
