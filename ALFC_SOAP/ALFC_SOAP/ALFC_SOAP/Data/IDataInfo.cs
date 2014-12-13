using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP
{
    public interface IDataInfo
    {
        List<IDataListItem> GetList();
    }
}
