using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHQSY_HSLFBLL : IBaseBLL
    {
        object SaveHQSY_HSLFJBXX(JCXX jcxx, HQSY_HSLFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadHQSY_HSLFJBXX(string HQSY_HSLFJBXXID);
    }
}
