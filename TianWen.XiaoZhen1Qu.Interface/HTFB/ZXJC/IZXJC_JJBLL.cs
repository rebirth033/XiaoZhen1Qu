using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJC_JJBLL : IBaseBLL
    {
        object SaveZXJC_JJJBXX(JCXX jcxx, ZXJC_JJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JJJBXX(string ID);
    }
}
