using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_DJZMBLL : IBaseBLL
    {
        object SavePFCG_DJZMJBXX(JCXX jcxx, PFCG_DJZMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_DJZMJBXX(string ID);
    }
}
