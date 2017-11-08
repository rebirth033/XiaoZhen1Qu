using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IQZZP_JZZPBLL : IBaseBLL
    {
        object SaveQZZP_JZZPJBXX(JCXX jcxx, QZZP_JZZPJBXX dzfjbxx);

        object LoadQZZP_JZZPJBXX(string ID);
    }
}
