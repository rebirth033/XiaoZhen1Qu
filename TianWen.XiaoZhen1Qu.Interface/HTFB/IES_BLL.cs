using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IES_BLL : IBaseBLL
    {
        object SaveES_JDJJBG_BGSBJBXX(JCXX jcxx, ES_JDJJBG_BGSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_BGSBJBXX(string ID);

        object SaveES_JDJJBG_ESJDJBXX(JCXX jcxx, ES_JDJJBG_ESJDJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_ESJDJBXX(string ID);

        object SaveES_JDJJBG_ESJJJBXX(JCXX jcxx, ES_JDJJBG_ESJJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_ESJJJBXX(string ID);

        object SaveES_JDJJBG_JJRYJBXX(JCXX jcxx, ES_JDJJBG_JJRYJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_JDJJBG_JJRYJBXX(string ID);

        object SaveES_MYFZMR_FZXMXBJBXX(JCXX jcxx, ES_MYFZMR_FZXMXBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_MYFZMR_FZXMXBJBXX(string ID);

        object SaveES_MYFZMR_MRBJJBXX(JCXX jcxx, ES_MYFZMR_MRBJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_MYFZMR_MRBJJBXX(string ID);

        object SaveES_MYFZMR_MYETYPWJJBXX(JCXX jcxx, ES_MYFZMR_MYETYPWJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_MYFZMR_MYETYPWJJBXX(string ID);

        object SaveES_QTES_CRYPJBXX(JCXX jcxx, ES_QTES_CRYPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_QTES_CRYPJBXX(string ID);

        object SaveES_QTES_ESSBJBXX(JCXX jcxx, ES_QTES_ESSBJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_QTES_ESSBJBXX(string ID);

        object SaveES_SJSM_BJBDNJBXX(JCXX jcxx, ES_SJSM_BJBDNJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_BJBDNJBXX(string ID);

        object SaveES_SJSM_ESSJJBXX(JCXX jcxx, ES_SJSM_ESSJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_ESSJJBXX(string ID);

        object SaveES_SJSM_PBDNJBXX(JCXX jcxx, ES_SJSM_PBDNJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_PBDNJBXX(string ID);

        object SaveES_SJSM_SMCPJBXX(JCXX jcxx, ES_SJSM_SMCPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_SMCPJBXX(string ID);

        object SaveES_SJSM_TSJJBXX(JCXX jcxx, ES_SJSM_TSJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_SJSM_TSJJBXX(string ID);

        object SaveES_WHYL_TSYXRJJBXX(JCXX jcxx, ES_WHYL_TSYXRJJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_TSYXRJJBXX(string ID);

        object SaveES_WHYL_WTHWYQJBXX(JCXX jcxx, ES_WHYL_WTHWYQJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_WTHWYQJBXX(string ID);

        object SaveES_WHYL_WYXNWPJBXX(JCXX jcxx, ES_WHYL_WYXNWPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_WYXNWPJBXX(string ID);

        object SaveES_WHYL_YSPSCPJBXX(JCXX jcxx, ES_WHYL_YSPSCPJBXX dzfjbxx, List<PHOTOS> photos);

        object LoadES_WHYL_YSPSCPJBXX(string ID);

        object SaveES_PWKQ_DYPJBXX(JCXX jcxx, ES_PWKQ_DYPJBXX dzfjbxx);

        object LoadES_PWKQ_DYPJBXX(string ID);

        object SaveES_PWKQ_QTKQJBXX(JCXX jcxx, ES_PWKQ_QTKQJBXX dzfjbxx);

        object LoadES_PWKQ_QTKQJBXX(string ID);

        object SaveES_PWKQ_XFKGWQJBXX(JCXX jcxx, ES_PWKQ_XFKGWQJBXX dzfjbxx);

        object LoadES_PWKQ_XFKGWQJBXX(string ID);

        object SaveES_PWKQ_YCMPJBXX(JCXX jcxx, ES_PWKQ_YCMPJBXX dzfjbxx);

        object LoadES_PWKQ_YCMPJBXX(string ID);

        object SaveES_PWKQ_YLYJDPJBXX(JCXX jcxx, ES_PWKQ_YLYJDPJBXX dzfjbxx);

        object LoadES_PWKQ_YLYJDPJBXX(string ID);
    }
}
