using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_JJHBBLL : IBaseBLL
    {
        object SaveZSJM_JJHBJBXX(JCXX jcxx, ZSJM_JJHBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JJHBJBXX(string ZSJM_JJHBJBXXID);
    }
}
