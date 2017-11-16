using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPWKQ_BLL : IBaseBLL
    {
        object SaveES_PWKQ_DYPJBXX(JCXX jcxx, ES_PWKQ_DYPJBXX dzfjbxx);

        object LoadES_PWKQ_DYPJBXX(string ID);

        object SaveES_PWKQ_QTKQJBXX(JCXX jcxx, ES_PWKQ_QTKQJBXX dzfjbxx);

        object LoadES_PWKQ_QTKQJBXX(string ID);

        object SaveES_PWKQ_XFKGWQJBXX(JCXX jcxx, ES_PWKQ_XFKGWQJBXX dzfjbxx);

        object LoadES_PWKQ_XFKGWQJBXX(string ID);

        object SaveES_PWKQ_YCMPJBXX(JCXX jcxx, ES_PWKQ_YCMPJBXX dzfjbxx);

        object LoadES_PWKQ_YCMPJBXX(string ID);

        object SaveES_PWKQ_YLYJDPJBXX(JCXX jcxx, ES_PWKQ_YLYJDPJBXX dzfjbxx);

        object LoadES_PWKQ_YLYJDPJBXX(string ID);
    }
}
