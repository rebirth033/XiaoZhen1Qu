using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_JDJJBG_ESJJBLL : IBaseBLL
    {
        object SaveES_JDJJBG_ESJJJBXX(JCXX jcxx, ES_JDJJBG_ESJJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_ESJJJBXX(string ID);
    }
}
