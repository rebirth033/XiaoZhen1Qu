using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_YYPXJSBLL : IBaseBLL
    {
        object SaveJYPX_YYPXJSJBXX(JCXX jcxx, JYPX_YYPXJSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YYPXJSJBXX(string ID);
    }
}
