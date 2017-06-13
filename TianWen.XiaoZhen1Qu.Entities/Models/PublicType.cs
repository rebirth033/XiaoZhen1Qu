using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TianWen.XiaoZhen1Qu.Entities.Models
{
    public enum EnResultType
    {
        Success = 1,
        Failed = 0,
        Error = 2
    }
    public class ExecuteResult
    {
        public EnResultType Result = EnResultType.Failed;
        public string Message = "";
        public object Value = null;
    }
}


