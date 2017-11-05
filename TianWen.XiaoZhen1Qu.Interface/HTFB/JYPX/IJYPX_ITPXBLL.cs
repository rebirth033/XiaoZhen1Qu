using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_ITPXBLL : IBaseBLL
    {
        object SaveJYPX_ITPXJBXX(JCXX jcxx, JYPX_ITPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_ITPXJBXX(string JYPX_ITPXJBXXID);
    }
}
