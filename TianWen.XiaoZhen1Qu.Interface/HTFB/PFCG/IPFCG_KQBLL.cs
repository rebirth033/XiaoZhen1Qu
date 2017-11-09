using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_KQBLL : IBaseBLL
    {
        object SavePFCG_KQJBXX(JCXX jcxx, PFCG_KQJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_KQJBXX(string ID);
    }
}
