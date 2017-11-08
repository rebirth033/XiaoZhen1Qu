using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_SJCHBLL : IBaseBLL
    {
        object SaveSWFW_SJCHJBXX(JCXX jcxx, SWFW_SJCHJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_SJCHJBXX(string ID);
    }
}
