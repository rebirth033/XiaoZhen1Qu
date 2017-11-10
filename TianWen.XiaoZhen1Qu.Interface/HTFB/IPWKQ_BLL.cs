using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPWKQ_BLL : IBaseBLL
    {
        object SavePWKQ_DYPJBXX(JCXX jcxx, PWKQ_DYPJBXX dzfjbxx);

        object LoadPWKQ_DYPJBXX(string ID);

        object SavePWKQ_QTKQJBXX(JCXX jcxx, PWKQ_QTKQJBXX dzfjbxx);

        object LoadPWKQ_QTKQJBXX(string ID);

        object SavePWKQ_XFKGWQJBXX(JCXX jcxx, PWKQ_XFKGWQJBXX dzfjbxx);

        object LoadPWKQ_XFKGWQJBXX(string ID);

        object SavePWKQ_YCMPJBXX(JCXX jcxx, PWKQ_YCMPJBXX dzfjbxx);

        object LoadPWKQ_YCMPJBXX(string ID);

        object SavePWKQ_YLYJDPJBXX(JCXX jcxx, PWKQ_YLYJDPJBXX dzfjbxx);

        object LoadPWKQ_YLYJDPJBXX(string ID);
    }
}
