using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_JZWXBLL : IBaseBLL
    {
        object SaveSWFW_JZWXJBXX(JCXX jcxx, SWFW_JZWXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_JZWXJBXX(string SWFW_JZWXJBXXID);
    }
}
