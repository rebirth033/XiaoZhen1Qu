using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_CZZXBLL : IBaseBLL
    {
        object SaveHQSY_CZZXJBXX(JCXX jcxx, HQSY_CZZXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_CZZXJBXX(string ID);
    }
}
