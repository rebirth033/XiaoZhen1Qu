using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IXXYL_BLL : IBaseBLL
    {
        object SaveXXYL_DIYSGFJBXX(JCXX jcxx, XXYL_DIYSGFJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_DIYSGFJBXX(string ID);

        object SaveXXYL_HPGJBXX(JCXX jcxx, XXYL_HPGJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_HPGJBXX(string ID);

        object SaveXXYL_HWJBXX(JCXX jcxx, XXYL_HWJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_HWJBXX(string ID);

        object SaveXXYL_QPZYJBXX(JCXX jcxx, XXYL_QPZYJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_QPZYJBXX(string ID);

        object SaveXXYL_TQTJBXX(JCXX jcxx, XXYL_TQTJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_TQTJBXX(string ID);

        object SaveXXYL_XYWQJBXX(JCXX jcxx, XXYL_XYWQJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_XYWQJBXX(string ID);

        object SaveXXYL_YDJBJBXX(JCXX jcxx, XXYL_YDJBJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_YDJBJBXX(string ID);

        object SaveXXYL_KTVJBXX(JCXX jcxx, XXYL_KTVJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_KTVJBXX(string ID);

        object SaveXXYL_YDJSJBXX(JCXX jcxx, XXYL_YDJSJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_YDJSJBXX(string ID);

        object SaveXXYL_ZLAMJBXX(JCXX jcxx, XXYL_ZLAMJBXX jbxx, List<PHOTOS> photos);

        object LoadXXYL_ZLAMJBXX(string ID);
    }
}
