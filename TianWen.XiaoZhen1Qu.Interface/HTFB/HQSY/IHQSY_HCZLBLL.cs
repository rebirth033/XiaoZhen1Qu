using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_HCZLBLL : IBaseBLL
    {
        object SaveHQSY_HCZLJBXX(JCXX jcxx, HQSY_HCZLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HCZLJBXX(string ID);
    }
}
