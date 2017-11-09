using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_ZKBLL : IBaseBLL
    {
        object SaveSWFW_ZKJBXX(JCXX jcxx, SWFW_ZKJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_ZKJBXX(string ID);
    }
}
