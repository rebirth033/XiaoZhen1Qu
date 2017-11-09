using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_MYWJBLL : IBaseBLL
    {
        object SavePFCG_MYWJJBXX(JCXX jcxx, PFCG_MYWJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_MYWJJBXX(string ID);
    }
}
