using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_SYBLL : IBaseBLL
    {
        object SaveHQSY_SYJBXX(JCXX jcxx, HQSY_SYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_SYJBXX(string HQSY_SYJBXXID);
    }
}
