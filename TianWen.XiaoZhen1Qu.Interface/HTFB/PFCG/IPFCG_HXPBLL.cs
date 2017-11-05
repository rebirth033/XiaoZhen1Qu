using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_HXPBLL : IBaseBLL
    {
        object SavePFCG_HXPJBXX(JCXX jcxx, PFCG_HXPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_HXPJBXX(string PFCG_HXPJBXXID);
    }
}
