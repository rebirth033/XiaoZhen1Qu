using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IBZZXBLL: IBaseBLL
    {
        IDAO DAO { get; set; }

        object SaveTJWT(BZZX_TJWT tjwt, List<PHOTOS> photos);

        object SaveWZJY(BZZX_WZJY wzyj, List<PHOTOS> photos);
    }
}
