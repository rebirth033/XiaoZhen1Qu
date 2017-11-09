using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_HLGPBLL : IBaseBLL
    {
        object SaveHQSY_HLGPJBXX(JCXX jcxx, HQSY_HLGPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HLGPJBXX(string ID);
    }
}
