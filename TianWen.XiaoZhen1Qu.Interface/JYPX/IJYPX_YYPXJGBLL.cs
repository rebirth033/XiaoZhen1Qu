using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IJYPX_YYPXJGBLL : IBaseBLL
    {
        object SaveJYPX_YYPXJGJBXX(JCXX jcxx, JYPX_YYPXJGJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadJYPX_YYPXJGJBXX(string JYPX_YYPXJGJBXXID);
    }
}
