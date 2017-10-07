using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_JXSBWXBLL : IBaseBLL
    {
        object SaveSWFW_JXSBWXJBXX(JCXX jcxx, SWFW_JXSBWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_JXSBWXJBXX(string SWFW_JXSBWXJBXXID);
    }
}
