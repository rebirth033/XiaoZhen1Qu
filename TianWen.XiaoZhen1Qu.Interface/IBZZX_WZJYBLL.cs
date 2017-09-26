using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBZZX_WZJYBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object SaveWZJY(JCXX jcxx, BZZX_WZJY wzyj, List<PHOTOS> photos);
    }
}
