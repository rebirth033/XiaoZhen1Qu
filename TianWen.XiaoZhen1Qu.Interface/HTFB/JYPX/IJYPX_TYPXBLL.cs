using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_TYPXBLL : IBaseBLL
    {
        object SaveJYPX_TYPXJBXX(JCXX jcxx, JYPX_TYPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_TYPXJBXX(string JYPX_TYPXJBXXID);
    }
}
