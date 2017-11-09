using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPWKQ_QTKQBLL : IBaseBLL
    {
        object SavePWKQ_QTKQJBXX(JCXX jcxx, PWKQ_QTKQJBXX dzfjbxx);

        object LoadPWKQ_QTKQJBXX(string ID);
    }
}
