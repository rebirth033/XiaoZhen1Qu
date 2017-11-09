using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_LPXSPBLL : IBaseBLL
    {
        object SaveZSJM_LPXSPJBXX(JCXX jcxx, ZSJM_LPXSPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_LPXSPJBXX(string ID);
    }
}
