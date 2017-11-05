using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_JDJJBG_JJRYBLL : IBaseBLL
    {
        object SaveES_JDJJBG_JJRYJBXX(JCXX jcxx, ES_JDJJBG_JJRYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_JJRYJBXX(string ES_JDJJBG_JJRYJBXXID);
    }
}
