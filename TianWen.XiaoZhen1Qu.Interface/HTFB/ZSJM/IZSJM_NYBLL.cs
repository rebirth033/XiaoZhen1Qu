using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_NYBLL : IBaseBLL
    {
        object SaveZSJM_NYJBXX(JCXX jcxx, ZSJM_NYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_NYJBXX(string ZSJM_NYJBXXID);
    }
}
