using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_SJSMBLL : IBaseBLL
    {
        object SavePFCG_SJSMJBXX(JCXX jcxx, PFCG_SJSMJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_SJSMJBXX(string PFCG_SJSMJBXXID);
    }
}
