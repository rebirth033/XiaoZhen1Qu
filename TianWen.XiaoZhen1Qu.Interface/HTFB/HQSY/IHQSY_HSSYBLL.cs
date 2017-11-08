using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_HSSYBLL : IBaseBLL
    {
        object SaveHQSY_HSSYJBXX(JCXX jcxx, HQSY_HSSYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HSSYJBXX(string ID);
    }
}
