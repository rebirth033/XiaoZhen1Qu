using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_SYSXBLL : IBaseBLL
    {
        object SaveSWFW_SYSXJBXX(JCXX jcxx, SWFW_SYSXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_SYSXJBXX(string ID);
    }
}
