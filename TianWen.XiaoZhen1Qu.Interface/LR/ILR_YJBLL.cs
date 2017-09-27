using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_YJBLL : IBaseBLL
    {
        object SaveLR_YJJBXX(JCXX jcxx, LR_YJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_YJJBXX(string LR_YJJBXXID);
    }
}
