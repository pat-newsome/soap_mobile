using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net.Attributes;  

namespace ALFC_SOAP.Model
{
    public class ReadingPlan : IDataListItem
    {
        [PrimaryKey, AutoIncrement]
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

        public bool IsSelected
        {
            get;
            set;
        }
        
    }
}
