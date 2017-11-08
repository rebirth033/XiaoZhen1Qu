using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IFC_CKCFTDCWBLL : IBaseBLL
    {
        object SaveCKCFTDCWJBXX(JCXX jcxx, FC_CKCFTDCWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_CKCFTDCWJBXX(string ID);
    }
}
