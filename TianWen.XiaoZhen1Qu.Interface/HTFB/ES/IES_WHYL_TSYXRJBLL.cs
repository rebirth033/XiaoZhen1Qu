using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_WHYL_TSYXRJBLL : IBaseBLL
    {
        object SaveES_WHYL_TSYXRJJBXX(JCXX jcxx, ES_WHYL_TSYXRJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_TSYXRJJBXX(string ID);
    }
}
