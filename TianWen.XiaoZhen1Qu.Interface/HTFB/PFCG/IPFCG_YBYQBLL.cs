using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IPFCG_YBYQBLL : IBaseBLL
    {
        object SavePFCG_YBYQJBXX(JCXX jcxx, PFCG_YBYQJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadPFCG_YBYQJBXX(string PFCG_YBYQJBXXID);
    }
}
