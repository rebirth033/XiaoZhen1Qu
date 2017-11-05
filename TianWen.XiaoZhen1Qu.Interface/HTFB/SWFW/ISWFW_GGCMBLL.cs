using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_GGCMBLL : IBaseBLL
    {
        object SaveSWFW_GGCMJBXX(JCXX jcxx, SWFW_GGCMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_GGCMJBXX(string SWFW_GGCMJBXXID);
    }
}
