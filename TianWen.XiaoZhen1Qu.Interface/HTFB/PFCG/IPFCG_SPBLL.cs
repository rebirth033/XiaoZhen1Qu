using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_SPBLL : IBaseBLL
    {
        object SavePFCG_SPJBXX(JCXX jcxx, PFCG_SPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_SPJBXX(string ID);
    }
}
