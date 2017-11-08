using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_TZDBBLL : IBaseBLL
    {
        object SaveSWFW_TZDBJBXX(JCXX jcxx, SWFW_TZDBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_TZDBJBXX(string ID);
    }
}
