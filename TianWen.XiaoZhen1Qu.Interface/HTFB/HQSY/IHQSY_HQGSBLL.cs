using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_HQGSBLL : IBaseBLL
    {
        object SaveHQSY_HQGSJBXX(JCXX jcxx, HQSY_HQGSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HQGSJBXX(string ID);
    }
}
