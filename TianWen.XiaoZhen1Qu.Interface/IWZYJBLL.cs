using System;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IWZYJBLL
    {
        IDAO DAO { get; set; }

        object SaveWZYJ(JCXX jcxx, WZYJ wzyj, List<PHOTOS> photos);
    }
}
