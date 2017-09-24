using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_JDJJBG_BGSBBLL : IBaseBLL
    {
        object SaveES_JDJJBG_BGSBJBXX(JCXX jcxx, ES_JDJJBG_BGSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_BGSBJBXX(string ES_JDJJBG_BGSBJBXXID);
    }
}
