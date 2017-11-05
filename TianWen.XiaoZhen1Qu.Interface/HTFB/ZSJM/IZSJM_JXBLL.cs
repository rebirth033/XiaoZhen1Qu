using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_JXBLL : IBaseBLL
    {
        object SaveZSJM_JXJBXX(JCXX jcxx, ZSJM_JXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JXJBXX(string ZSJM_JXJBXXID);
    }
}
