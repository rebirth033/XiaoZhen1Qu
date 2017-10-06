using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_WLBXWHBLL : IBaseBLL
    {
        object SaveSWFW_WLBXWHJBXX(JCXX jcxx, SWFW_WLBXWHJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_WLBXWHJBXX(string SWFW_WLBXWHJBXXID);
    }
}
