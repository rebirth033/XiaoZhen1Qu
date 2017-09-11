using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFC_XZLBLL : IBaseBLL
    {
        object SaveXZLJBXX(JCXX jcxx, FC_XZLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_XZLJBXX(string FC_XZLJBXXID);
    }
}
