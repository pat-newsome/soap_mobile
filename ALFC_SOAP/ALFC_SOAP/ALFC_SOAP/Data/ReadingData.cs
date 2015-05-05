using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALFC_SOAP.Model;
using SQLite.Net;
using Xamarin.Forms;

namespace ALFC_SOAP.Data
{
    public class ReadingData
    {
        
        static object locker = new object();

        SQLiteConnection database;

        public ReadingData()
        {
            //readingplan = new List<Reading>();
            
            database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			database.CreateTable<Reading>();
        }

        public IEnumerable<Reading> GetItems(int planId)
        {
            lock (locker)
            {
                return database.Query<Reading>(string.Format("SELECT * FROM [Reading] WHERE [PlanId] = {0}", planId));
            }
        }

        public IEnumerable<Reading> GetItemsNotRead()
        {
            lock (locker)
            {
                return database.Query<Reading>("SELECT * FROM [Reading] WHERE [HaveRead] = 0");
            }
        }

        public Reading GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Reading>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveItem(Reading item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Reading>(id);
            }
        }
    }
}
