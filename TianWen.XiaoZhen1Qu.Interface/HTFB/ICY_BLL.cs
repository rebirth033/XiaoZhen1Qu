using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface.HTFB
{
    public interface ICY_BLL : IBaseBLL
    {
        object SaveCY_KCTSJBXX(JCXX jcxx, CY_KCTSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCY_KCTSJBXX(string ID);

        object SaveCY_MSJBXX(JCXX jcxx, CY_MSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCY_MSJBXX(string ID);

        object SaveCY_WMJBXX(JCXX jcxx, CY_WMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCY_WMJBXX(string ID);
    }
}
