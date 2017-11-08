using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_TYJLBLL : IBaseBLL
    {
        object SaveJYPX_TYJLJBXX(JCXX jcxx, JYPX_TYJLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_TYJLJBXX(string ID);
    }
}
