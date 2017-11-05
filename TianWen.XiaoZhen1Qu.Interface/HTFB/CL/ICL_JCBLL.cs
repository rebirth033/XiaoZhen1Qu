using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICL_JCBLL : IBaseBLL
    {
        object SaveCL_JCJBXX(JCXX jcxx, CL_JCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_JCJBXX(string CL_JCJBXXID);
    }
}
