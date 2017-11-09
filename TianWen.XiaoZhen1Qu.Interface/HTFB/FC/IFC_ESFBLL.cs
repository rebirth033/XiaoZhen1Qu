using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.Models.FC;

namespace TianWen.XiaoZhen1Qu.Interface.HTFB.FC
{
    public interface IFC_ESFBLL : IBaseBLL
    {
        object SaveFC_ESFJBXX(JCXX jcxx, FC_ESFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadFC_ESFJBXX(string ID);
    }
}
