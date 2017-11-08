using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_GLPXBLL : IBaseBLL
    {
        object SaveJYPX_GLPXJBXX(JCXX jcxx, JYPX_GLPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_GLPXJBXX(string ID);
    }
}
