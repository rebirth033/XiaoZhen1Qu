using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_MYFZMR_MYETYPWJBLL : IBaseBLL
    {
        object SaveES_MYFZMR_MYETYPWJJBXX(JCXX jcxx, ES_MYFZMR_MYETYPWJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_MYFZMR_MYETYPWJJBXX(string ES_MYFZMR_MYETYPWJJBXXID);
    }
}
