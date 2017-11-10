using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IZSJM_BLL : IBaseBLL
    {
        object SaveZSJM_CYJBXX(JCXX jcxx, ZSJM_CYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_CYJBXX(string ID);

        object SaveZSJM_FZXBJBXX(JCXX jcxx, ZSJM_FZXBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_FZXBJBXX(string ID);

        object SaveZSJM_JCJBXX(JCXX jcxx, ZSJM_JCJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JCJBXX(string ID);

        object SaveZSJM_JJHBJBXX(JCXX jcxx, ZSJM_JJHBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JJHBJBXX(string ID);

        object SaveZSJM_JXJBXX(JCXX jcxx, ZSJM_JXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JXJBXX(string ID);

        object SaveZSJM_JYPXJBXX(JCXX jcxx, ZSJM_JYPXJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_JYPXJBXX(string ID);

        object SaveZSJM_LPXSPJBXX(JCXX jcxx, ZSJM_LPXSPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_LPXSPJBXX(string ID);

        object SaveZSJM_MRBJJBXX(JCXX jcxx, ZSJM_MRBJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_MRBJJBXX(string ID);

        object SaveZSJM_NYJBXX(JCXX jcxx, ZSJM_NYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_NYJBXX(string ID);

        object SaveZSJM_QCFWJBXX(JCXX jcxx, ZSJM_QCFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_QCFWJBXX(string ID);

        object SaveZSJM_SHFWJBXX(JCXX jcxx, ZSJM_SHFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_SHFWJBXX(string ID);

        object SaveZSJM_TSJBXX(JCXX jcxx, ZSJM_TSJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_TSJBXX(string ID);

        object SaveZSJM_WLFWJBXX(JCXX jcxx, ZSJM_WLFWJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_WLFWJBXX(string ID);

        object SaveZSJM_WTMYETJBXX(JCXX jcxx, ZSJM_WTMYETJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadZSJM_WTMYETJBXX(string ID);
    }
}
