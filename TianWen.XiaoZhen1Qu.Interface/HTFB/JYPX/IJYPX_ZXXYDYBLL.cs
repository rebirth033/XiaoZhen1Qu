using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_ZXXYDYBLL : IBaseBLL
    {
        object SaveJYPX_ZXXYDYJBXX(JCXX jcxx, JYPX_ZXXYDYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ZXXYDYJBXX(string ID);
    }
}
