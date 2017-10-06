using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_HYWLBLL : IBaseBLL
    {
        object SaveSWFW_HYWLJBXX(JCXX jcxx, SWFW_HYWLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_HYWLJBXX(string SWFW_HYWLJBXXID);
    }
}
