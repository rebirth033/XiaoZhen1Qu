using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ICW_CWYPSPBLL : IBaseBLL
    {
        object SaveCW_CWYPSPJBXX(JCXX jcxx, CW_CWYPSPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadCW_CWYPSPJBXX(string CW_CWYPSPJBXXID);
    }
}
