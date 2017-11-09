using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_WTMYETBLL : IBaseBLL
    {
        object SaveZSJM_WTMYETJBXX(JCXX jcxx, ZSJM_WTMYETJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_WTMYETJBXX(string ID);
    }
}
