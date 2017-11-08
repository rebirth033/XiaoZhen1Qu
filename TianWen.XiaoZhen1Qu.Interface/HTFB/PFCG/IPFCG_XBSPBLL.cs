using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_XBSPBLL : IBaseBLL
    {
        object SavePFCG_XBSPJBXX(JCXX jcxx, PFCG_XBSPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_XBSPJBXX(string ID);
    }
}
