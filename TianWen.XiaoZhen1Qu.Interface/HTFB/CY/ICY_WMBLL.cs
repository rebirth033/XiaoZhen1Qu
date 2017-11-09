using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICY_WMBLL : IBaseBLL
    {
        object SaveCY_WMJBXX(JCXX jcxx, CY_WMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCY_WMJBXX(string ID);
    }
}
