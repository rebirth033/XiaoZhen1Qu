using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_SJPXBLL : IBaseBLL
    {
        object SaveJYPX_SJPXJBXX(JCXX jcxx, JYPX_SJPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_SJPXJBXX(string JYPX_SJPXJBXXID);
    }
}
