using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IHFCZBLL : IBaseBLL
    {
        IDAO DAO { get; set; }

        object SearchMobilePhoneGuiSuArea(string YHID, string MobileNo);
    }
}
