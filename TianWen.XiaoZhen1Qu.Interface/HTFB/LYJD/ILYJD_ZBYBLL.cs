using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_ZBYBLL : IBaseBLL
    {
        object SaveLYJD_ZBYJBXX(JCXX jcxx, LYJD_ZBYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_ZBYJBXX(string ID);
    }
}
