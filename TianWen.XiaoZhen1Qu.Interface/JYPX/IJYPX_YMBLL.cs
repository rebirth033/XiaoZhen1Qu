using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_YMBLL : IBaseBLL
    {
        object SaveJYPX_YMJBXX(JCXX jcxx, JYPX_YMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YMJBXX(string JYPX_YMJBXXID);
    }
}
