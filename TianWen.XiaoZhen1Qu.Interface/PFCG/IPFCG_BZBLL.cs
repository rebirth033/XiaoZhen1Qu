using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_BZBLL : IBaseBLL
    {
        object SavePFCG_BZJBXX(JCXX jcxx, PFCG_BZJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_BZJBXX(string PFCG_BZJBXXID);
    }
}
