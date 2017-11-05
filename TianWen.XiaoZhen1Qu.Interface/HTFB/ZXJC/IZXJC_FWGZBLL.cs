using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJC_FWGZBLL : IBaseBLL
    {
        object SaveZXJC_FWGZJBXX(JCXX jcxx, ZXJC_FWGZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_FWGZJBXX(string ZXJC_FWGZJBXXID);
    }
}
