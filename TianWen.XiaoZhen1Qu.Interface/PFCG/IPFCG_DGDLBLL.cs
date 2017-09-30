using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_DGDLBLL : IBaseBLL
    {
        object SavePFCG_DGDLJBXX(JCXX jcxx, PFCG_DGDLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_DGDLJBXX(string PFCG_DGDLJBXXID);
    }
}
