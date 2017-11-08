using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_JDJJBG_ESJDBLL : IBaseBLL
    {
        object SaveES_JDJJBG_ESJDJBXX(JCXX jcxx, ES_JDJJBG_ESJDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_ESJDJBXX(string ID);
    }
}
