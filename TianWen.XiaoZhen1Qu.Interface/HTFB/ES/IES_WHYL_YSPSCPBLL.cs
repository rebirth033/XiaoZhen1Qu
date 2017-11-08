using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_WHYL_YSPSCPBLL : IBaseBLL
    {
        object SaveES_WHYL_YSPSCPJBXX(JCXX jcxx, ES_WHYL_YSPSCPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_YSPSCPJBXX(string ID);
    }
}
