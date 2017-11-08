using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPWKQ_YCMPBLL : IBaseBLL
    {
        object SavePWKQ_YCMPJBXX(JCXX jcxx, PWKQ_YCMPJBXX dzfjbxx);

        object LoadPWKQ_YCMPJBXX(string ID);
    }
}
