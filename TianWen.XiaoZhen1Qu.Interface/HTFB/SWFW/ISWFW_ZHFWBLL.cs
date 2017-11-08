using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ISWFW_ZHFWBLL : IBaseBLL
    {
        object SaveSWFW_ZHFWJBXX(JCXX jcxx, SWFW_ZHFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadSWFW_ZHFWJBXX(string ID);
    }
}
