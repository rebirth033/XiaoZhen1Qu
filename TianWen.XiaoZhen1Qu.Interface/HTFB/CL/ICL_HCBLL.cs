using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICL_HCBLL : IBaseBLL
    {
        object SaveCL_HCJBXX(JCXX jcxx, CL_HCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_HCJBXX(string ID);
    }
}
