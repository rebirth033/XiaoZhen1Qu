using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICL_MTCBLL : IBaseBLL
    {
        object SaveCL_MTCJBXX(JCXX jcxx, CL_MTCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_MTCJBXX(string CL_MTCJBXXID);
    }
}
