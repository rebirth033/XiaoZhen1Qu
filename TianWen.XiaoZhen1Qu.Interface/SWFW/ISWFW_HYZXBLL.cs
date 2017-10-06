using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_HYZXBLL : IBaseBLL
    {
        object SaveSWFW_HYZXJBXX(JCXX jcxx, SWFW_HYZXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_HYZXJBXX(string SWFW_HYZXJBXXID);
    }
}
