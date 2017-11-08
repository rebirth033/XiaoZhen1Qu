using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_JJJGBLL : IBaseBLL
    {
        object SaveJYPX_JJJGJBXX(JCXX jcxx, JYPX_JJJGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_JJJGJBXX(string ID);
    }
}
