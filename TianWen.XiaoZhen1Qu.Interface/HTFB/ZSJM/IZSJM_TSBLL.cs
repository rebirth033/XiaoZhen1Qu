using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_TSBLL : IBaseBLL
    {
        object SaveZSJM_TSJBXX(JCXX jcxx, ZSJM_TSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_TSJBXX(string ZSJM_TSJBXXID);
    }
}
