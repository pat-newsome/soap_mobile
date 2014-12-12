using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALFC_SOAP.Entities;
using Xamarin.Forms.Labs.Data;

namespace ALFC_SOAP.Data
{
    class ReadingInfo
    {
        int currentDayofYear;
        

        public ReadingInfo()
        {
            currentDayofYear = DateTime.Now.DayOfYear;
            
        }

        

        private List<Reading> CurrentReadingList(int offSet)
        {
            var readings = new List<Reading>();
            


            return readings;
        }
    }
}
