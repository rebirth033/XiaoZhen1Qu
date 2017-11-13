using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface.HTFB
{
    public interface ICL_BLL : IBaseBLL
    {
        object SaveCL_GCCJBXX(JCXX jcxx, CL_GCCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_GCCJBXX(string ID);

        object SaveCL_HCJBXX(JCXX jcxx, CL_HCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_HCJBXX(string ID);

        object SaveCL_JCJBXX(JCXX jcxx, CL_JCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_JCJBXX(string ID);

        object SaveCL_KCJBXX(JCXX jcxx, CL_KCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_KCJBXX(string ID);

        object SaveCL_MTCJBXX(JCXX jcxx, CL_MTCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_MTCJBXX(string ID);

        object SaveCL_ZXCJBXX(JCXX jcxx, CL_ZXCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_ZXCJBXX(string ID);

        object SaveCL_DDCJBXX(JCXX jcxx, CL_DDCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_DDCJBXX(string ID);

        object SaveCL_SLCJBXX(JCXX jcxx, CL_SLCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCL_SLCJBXX(string ID);
    }
}
