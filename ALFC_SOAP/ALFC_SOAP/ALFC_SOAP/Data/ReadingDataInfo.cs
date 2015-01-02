using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALFC_SOAP.Entities;
using Xamarin.Forms.Labs.Data;

namespace ALFC_SOAP.Data
{
    class ReadingDataInfo : IDataInfo
    {
        int currentDayofYear;
        
        
        public ReadingDataInfo()
        {
            currentDayofYear = DateTime.Now.DayOfYear;     
        }

        

        private List<Reading> CurrentReadingList(int planId)
        {
            var readings = new List<Reading>();
            
            //Select list of readings from data

            

            return readings;
        }

        public List<IDataListItem> GetList()
        {
            var readings = new List<IDataListItem>();

            readings.Add(new Reading { Id = 1, Name = "180 days of Abiding New Testament", Value= "New Testament" });
            readings.Add(new Reading { Id = 2, Name = "180 days of Abiding Wisdom", Value = "Wisdom Liteture" });
            readings.Add(new Reading { Id = 3, Name = "Prophecy", Value = "Revelation, Ezkial" });
            return readings;
        }


    }
}
