using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPWKQ_DYPBLL : IBaseBLL
    {
        object SavePWKQ_DYPJBXX(JCXX jcxx, PWKQ_DYPJBXX dzfjbxx);

        object LoadPWKQ_DYPJBXX(string PWKQ_DYPJBXXID);
    }
}
