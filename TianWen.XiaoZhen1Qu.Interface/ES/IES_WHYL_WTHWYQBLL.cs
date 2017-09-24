using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_WHYL_WTHWYQBLL : IBaseBLL
    {
        object SaveES_WHYL_WTHWYQJBXX(JCXX jcxx, ES_WHYL_WTHWYQJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_WTHWYQJBXX(string ES_WHYL_WTHWYQJBXXID);
    }
}
