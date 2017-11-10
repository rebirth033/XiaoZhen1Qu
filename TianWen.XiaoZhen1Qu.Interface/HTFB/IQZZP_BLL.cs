using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IQZZP_BLL : IBaseBLL
    {
        object SaveQZZP_JZZPJBXX(JCXX jcxx, QZZP_JZZPJBXX dzfjbxx);

        object LoadQZZP_JZZPJBXX(string ID);

        object SaveQZZP_QZZPJBXX(JCXX jcxx, QZZP_QZZPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadQZZP_QZZPJBXX(string ID);
    }
}
