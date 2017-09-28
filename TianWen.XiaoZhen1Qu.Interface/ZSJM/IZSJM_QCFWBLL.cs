using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_QCFWBLL : IBaseBLL
    {
        object SaveZSJM_QCFWJBXX(JCXX jcxx, ZSJM_QCFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_QCFWJBXX(string ZSJM_QCFWJBXXID);
    }
}
