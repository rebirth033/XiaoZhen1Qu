using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFC_SPBLL : IBaseBLL
    {
        object SaveSPJBXX(JCXX jcxx, FC_SPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_SPJBXX(string FC_SPJBXXID);
    }
}
