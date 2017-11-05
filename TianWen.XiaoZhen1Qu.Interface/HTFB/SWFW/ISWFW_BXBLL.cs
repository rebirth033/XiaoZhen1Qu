using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_BXBLL : IBaseBLL
    {
        object SaveSWFW_BXJBXX(JCXX jcxx, SWFW_BXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_BXJBXX(string SWFW_BXJBXXID);
    }
}
