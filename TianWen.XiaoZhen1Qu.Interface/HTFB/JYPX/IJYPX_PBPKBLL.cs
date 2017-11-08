using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_PBPKBLL : IBaseBLL
    {
        object SaveJYPX_PBPKJBXX(JCXX jcxx, JYPX_PBPKJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_PBPKJBXX(string ID);
    }
}
