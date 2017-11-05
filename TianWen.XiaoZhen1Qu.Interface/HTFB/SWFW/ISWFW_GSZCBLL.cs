using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_GSZCBLL : IBaseBLL
    {
        object SaveSWFW_GSZCJBXX(JCXX jcxx, SWFW_GSZCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_GSZCJBXX(string SWFW_GSZCJBXXID);
    }
}
