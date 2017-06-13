namespace TianWen.WebForm.Controls
{
    using System;
    using System.Data;
    using TianWen.Plus4MEF;

    public interface IDivTreeDataReader : ITianWenComponent
    {
        DataTable GetDataByParent(string parentId);
    }
}

