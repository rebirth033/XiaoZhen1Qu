using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICW_HNYCBLL : IBaseBLL
    {
        object SaveCW_HNYCJBXX(JCXX jcxx, CW_HNYCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_HNYCJBXX(string ID);
    }
}
