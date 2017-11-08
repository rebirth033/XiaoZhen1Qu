using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_LPDZBLL : IBaseBLL
    {
        object SaveSWFW_LPDZJBXX(JCXX jcxx, SWFW_LPDZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_LPDZJBXX(string ID);
    }
}
