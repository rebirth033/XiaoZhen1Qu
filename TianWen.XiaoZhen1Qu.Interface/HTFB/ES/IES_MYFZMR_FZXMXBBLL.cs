using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_MYFZMR_FZXMXBBLL : IBaseBLL
    {
        object SaveES_MYFZMR_FZXMXBJBXX(JCXX jcxx, ES_MYFZMR_FZXMXBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_MYFZMR_FZXMXBJBXX(string ES_MYFZMR_FZXMXBJBXXID);
    }
}
