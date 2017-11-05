using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_FLZXBLL : IBaseBLL
    {
        object SaveSWFW_FLZXJBXX(JCXX jcxx, SWFW_FLZXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_FLZXJBXX(string SWFW_FLZXJBXXID);
    }
}
