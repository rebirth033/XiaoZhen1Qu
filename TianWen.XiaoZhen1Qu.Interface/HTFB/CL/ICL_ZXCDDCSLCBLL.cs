using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICL_ZXCDDCSLCBLL : IBaseBLL
    {
        object SaveCL_ZXCDDCSLCJBXX(JCXX jcxx, CL_ZXCDDCSLCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_ZXCDDCSLCJBXX(string ID);
    }
}
