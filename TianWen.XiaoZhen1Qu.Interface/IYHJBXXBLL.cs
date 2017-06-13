using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IYHJBXXBLL
    {
        IDAO DAO { get; set; }

        DataTable GetYHJBXXListByPage();
    }
}
