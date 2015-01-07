using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.Entities
{
    public class Reading : IDataListItem
    {
        public int Id
        {
            get;
            set;
        }

        public int PlanId
        {
            get;
            set;
        }

        public int BookId { get; set; }

        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string UrlSearch { get { return string.Format("{0} {1}", Name, Value); } }
    }
}
