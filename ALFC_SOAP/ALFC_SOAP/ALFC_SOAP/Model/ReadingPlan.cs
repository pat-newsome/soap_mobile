using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.Model
{
    public class ReadingPlan : IDataListItem
    {
        public int Id
        {
            get;
            set;
        }

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

        public List<Reading> AssociatedReadings { get; set; }

        public ReadingPlan()
        {
            AssociatedReadings = new List<Reading>();
        }
    }
}
