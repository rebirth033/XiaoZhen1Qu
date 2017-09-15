using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_WHYL_WYXNWPBLL : IBaseBLL
    {
        object SaveES_WHYL_WYXNWPJBXX(JCXX jcxx, ES_WHYL_WYXNWPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_WYXNWPJBXX(string ES_WHYL_WYXNWPJBXXID);
    }
}
