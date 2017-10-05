using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_CWKJPGBLL : IBaseBLL
    {
        object SaveSWFW_CWKJPGJBXX(JCXX jcxx, SWFW_CWKJPGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_CWKJPGJBXX(string SWFW_CWKJPGJBXXID);
    }
}
