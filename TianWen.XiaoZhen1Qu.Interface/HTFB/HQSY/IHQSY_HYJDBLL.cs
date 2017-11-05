using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_HYJDBLL : IBaseBLL
    {
        object SaveHQSY_HYJDJBXX(JCXX jcxx, HQSY_HYJDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HYJDJBXX(string HQSY_HYJDJBXXID);
    }
}
