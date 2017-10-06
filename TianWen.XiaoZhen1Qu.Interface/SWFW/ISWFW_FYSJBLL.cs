using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_FYSJBLL : IBaseBLL
    {
        object SaveSWFW_FYSJJBXX(JCXX jcxx, SWFW_FYSJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_FYSJJBXX(string SWFW_FYSJJBXXID);
    }
}
