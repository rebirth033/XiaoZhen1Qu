using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPWKQ_YLYJDPBLL : IBaseBLL
    {
        object SavePWKQ_YLYJDPJBXX(JCXX jcxx, PWKQ_YLYJDPJBXX dzfjbxx);

        object LoadPWKQ_YLYJDPJBXX(string ID);
    }
}
