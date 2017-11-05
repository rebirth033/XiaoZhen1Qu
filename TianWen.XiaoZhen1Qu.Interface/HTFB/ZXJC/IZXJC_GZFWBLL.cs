using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJC_GZFWBLL : IBaseBLL
    {
        object SaveZXJC_GZFWJBXX(JCXX jcxx, ZXJC_GZFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_GZFWJBXX(string ZXJC_GZFWJBXXID);
    }
}
