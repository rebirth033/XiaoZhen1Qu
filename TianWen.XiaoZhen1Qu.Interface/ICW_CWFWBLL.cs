using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICW_CWFWBLL : IBaseBLL
    {
        object SaveCW_CWFWJBXX(JCXX jcxx, CW_CWFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWFWJBXX(string CW_CWFWJBXXID);
    }
}
