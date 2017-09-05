using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IWZYJBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object SaveWZJY(JCXX jcxx, WZJY wzyj, List<PHOTOS> photos);
    }
}
