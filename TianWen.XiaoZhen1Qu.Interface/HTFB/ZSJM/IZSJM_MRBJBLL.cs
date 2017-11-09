using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_MRBJBLL : IBaseBLL
    {
        object SaveZSJM_MRBJJBXX(JCXX jcxx, ZSJM_MRBJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_MRBJJBXX(string ID);
    }
}
