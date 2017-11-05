using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZXJC_JFJSBLL : IBaseBLL
    {
        object SaveZXJC_JFJSJBXX(JCXX jcxx, ZXJC_JFJSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZXJC_JFJSJBXX(string ZXJC_JFJSJBXXID);
    }
}
