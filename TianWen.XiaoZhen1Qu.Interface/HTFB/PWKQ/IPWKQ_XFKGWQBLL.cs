using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPWKQ_XFKGWQBLL : IBaseBLL
    {
        object SavePWKQ_XFKGWQJBXX(JCXX jcxx, PWKQ_XFKGWQJBXX dzfjbxx);

        object LoadPWKQ_XFKGWQJBXX(string PWKQ_XFKGWQJBXXID);
    }
}
