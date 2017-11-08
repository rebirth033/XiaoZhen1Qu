using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_JCBLL : IBaseBLL
    {
        object SaveZSJM_JCJBXX(JCXX jcxx, ZSJM_JCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JCJBXX(string ID);
    }
}
