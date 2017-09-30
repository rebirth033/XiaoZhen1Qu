using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IQZZP_QZZPBLL : IBaseBLL
    {
        object SaveQZZP_QZZPJBXX(JCXX jcxx, QZZP_QZZPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadQZZP_QZZPJBXX(string QZZP_QZZPJBXXID);
    }
}
