using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_CYBLL : IBaseBLL
    {
        object SaveZSJM_CYJBXX(JCXX jcxx, ZSJM_CYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_CYJBXX(string ID);
    }
}
