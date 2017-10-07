using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_ZXXFDBBLL : IBaseBLL
    {
        object SaveJYPX_ZXXFDBJBXX(JCXX jcxx, JYPX_ZXXFDBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ZXXFDBJBXX(string JYPX_ZXXFDBJBXXID);
    }
}
