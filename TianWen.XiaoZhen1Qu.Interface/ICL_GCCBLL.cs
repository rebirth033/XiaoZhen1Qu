using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICL_GCCBLL : IBaseBLL
    {
        object SaveCL_GCCJBXX(JCXX jcxx, CL_GCCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_GCCJBXX(string CL_GCCJBXXID);
    }
}
