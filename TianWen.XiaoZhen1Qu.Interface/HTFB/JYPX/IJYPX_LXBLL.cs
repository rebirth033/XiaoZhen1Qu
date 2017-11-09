using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_LXBLL : IBaseBLL
    {
        object SaveJYPX_LXJBXX(JCXX jcxx, JYPX_LXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_LXJBXX(string ID);
    }
}
