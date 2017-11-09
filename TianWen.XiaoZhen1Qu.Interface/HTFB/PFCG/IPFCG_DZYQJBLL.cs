using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_DZYQJBLL : IBaseBLL
    {
        object SavePFCG_DZYQJJBXX(JCXX jcxx, PFCG_DZYQJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_DZYQJJBXX(string ID);
    }
}
