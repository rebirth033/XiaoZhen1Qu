using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_SHFWBLL : IBaseBLL
    {
        object SaveZSJM_SHFWJBXX(JCXX jcxx, ZSJM_SHFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_SHFWJBXX(string ID);
    }
}
