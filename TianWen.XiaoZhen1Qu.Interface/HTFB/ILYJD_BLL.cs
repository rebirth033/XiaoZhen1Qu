using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILYJD_BLL : IBaseBLL
    {

        object SaveLYJD_DYDDRJBXX(JCXX jcxx, LYJD_DYDDRJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_DYDDRJBXX(string ID);

        object SaveLYJD_GNYJBXX(JCXX jcxx, LYJD_GNYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_GNYJBXX(string ID);

        object SaveLYJD_JDZSYDJBXX(JCXX jcxx, LYJD_JDZSYDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_JDZSYDJBXX(string ID);

        object SaveLYJD_JPJBXX(JCXX jcxx, LYJD_JPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_JPJBXX(string ID);

        object SaveLYJD_LXSJBXX(JCXX jcxx, LYJD_LXSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_LXSJBXX(string ID);

        object SaveLYJD_QZFWJBXX(JCXX jcxx, LYJD_QZFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_QZFWJBXX(string ID);

        object SaveLYJD_ZBYJBXX(JCXX jcxx, LYJD_ZBYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLYJD_ZBYJBXX(string ID);
    }
}
