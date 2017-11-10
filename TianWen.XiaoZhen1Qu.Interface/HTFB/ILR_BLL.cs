using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface ILR_BLL : IBaseBLL
    {
        object SaveLR_KQHLJBXX(JCXX jcxx, LR_KQHLJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_KQHLJBXX(string ID);

        object SaveLR_MFHFJBXX(JCXX jcxx, LR_MFHFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MFHFJBXX(string ID);

        object SaveLR_MJJBXX(JCXX jcxx, LR_MJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MJJBXX(string ID);

        object SaveLR_MRHFJBXX(JCXX jcxx, LR_MRHFJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MRHFJBXX(string ID);

        object SaveLR_MTSSJBXX(JCXX jcxx, LR_MTSSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_MTSSJBXX(string ID);

        object SaveLR_SPAJBXX(JCXX jcxx, LR_SPAJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_SPAJBXX(string ID);

        object SaveLR_TJJBXX(JCXX jcxx, LR_TJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_TJJBXX(string ID);

        object SaveLR_WDJBXX(JCXX jcxx, LR_WDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_WDJBXX(string ID);

        object SaveLR_WSJBXX(JCXX jcxx, LR_WSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_WSJBXX(string ID);

        object SaveLR_YJJBXX(JCXX jcxx, LR_YJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadLR_YJJBXX(string ID);
    }
}
