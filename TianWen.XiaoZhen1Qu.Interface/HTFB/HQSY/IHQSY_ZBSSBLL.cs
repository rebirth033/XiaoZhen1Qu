using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_ZBSSBLL : IBaseBLL
    {
        object SaveHQSY_ZBSSJBXX(JCXX jcxx, HQSY_ZBSSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_ZBSSJBXX(string ID);
    }
}
