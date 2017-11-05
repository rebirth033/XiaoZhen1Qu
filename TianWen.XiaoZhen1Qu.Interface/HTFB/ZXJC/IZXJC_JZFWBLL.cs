using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJC_JZFWBLL : IBaseBLL
    {
        object SaveZXJC_JZFWJBXX(JCXX jcxx, ZXJC_JZFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JZFWJBXX(string ZXJC_JZFWJBXXID);
    }
}
