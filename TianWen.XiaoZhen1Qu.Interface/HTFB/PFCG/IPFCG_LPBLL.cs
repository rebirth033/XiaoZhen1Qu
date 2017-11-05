using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_LPBLL : IBaseBLL
    {
        object SavePFCG_LPJBXX(JCXX jcxx, PFCG_LPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_LPJBXX(string PFCG_LPJBXXID);
    }
}
