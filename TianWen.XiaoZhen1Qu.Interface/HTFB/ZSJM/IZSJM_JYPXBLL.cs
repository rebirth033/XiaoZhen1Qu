using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_JYPXBLL : IBaseBLL
    {
        object SaveZSJM_JYPXJBXX(JCXX jcxx, ZSJM_JYPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JYPXJBXX(string ZSJM_JYPXJBXXID);
    }
}
