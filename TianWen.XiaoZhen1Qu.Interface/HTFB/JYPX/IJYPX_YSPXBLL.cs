using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_YSPXBLL : IBaseBLL
    {
        object SaveJYPX_YSPXJBXX(JCXX jcxx, JYPX_YSPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YSPXJBXX(string ID);
    }
}
