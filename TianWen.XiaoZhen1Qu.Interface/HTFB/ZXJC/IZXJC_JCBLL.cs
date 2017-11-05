using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJC_JCBLL : IBaseBLL
    {
        object SaveZXJC_JCJBXX(JCXX jcxx, ZXJC_JCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JCJBXX(string ZXJC_JCJBXXID);
    }
}
