using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_HZPBLL : IBaseBLL
    {
        object SavePFCG_HZPJBXX(JCXX jcxx, PFCG_HZPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_HZPJBXX(string PFCG_HZPJBXXID);
    }
}
