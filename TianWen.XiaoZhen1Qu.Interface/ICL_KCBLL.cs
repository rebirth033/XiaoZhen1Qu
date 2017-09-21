using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICL_KCBLL : IBaseBLL
    {
        object SaveCL_KCJBXX(JCXX jcxx, CL_KCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_KCJBXX(string CL_KCJBXXID);
    }
}
