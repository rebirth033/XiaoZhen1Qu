using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_SBZLBLL : IBaseBLL
    {
        object SaveSWFW_SBZLJBXX(JCXX jcxx, SWFW_SBZLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_SBZLJBXX(string SWFW_SBZLJBXXID);
    }
}
