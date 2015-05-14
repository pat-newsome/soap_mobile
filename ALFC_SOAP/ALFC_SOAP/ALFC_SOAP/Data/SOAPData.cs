using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using ALFC_SOAP.Model;

namespace ALFC_SOAP.Data
{
    public class SOAPData
    {
        static object locker = new object();

        SQLiteConnection database;

        public SOAPData()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<Soap>();
        }
   
    
        public IEnumerable<Soap> GetItems()
            {
                lock (locker)
                {
                    return database.Query<Soap>(string.Format("SELECT * FROM [Soap]"));
                }
            }

        public IEnumerable<Soap> GetReadingItems(int id)
            {
                lock (locker)
                {
                    return database.Query<Soap>(string.Format("SELECT * FROM [Soap] WHERE ReadingId = {0}", id));
                }
            }
        public IEnumerable<Soap> GetPlanItems(int id)
        {
            lock (locker)
            {
                return database.Query<Soap>(string.Format("SELECT * FROM [Soap] WHERE PlanId = {0}", id));
            }
        }
        public Soap GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Soap>().FirstOrDefault(x => x.Id == id);
            }
        }
    

        public int SaveItem(Soap item)
        {
            lock (locker)
            {
                if(item.Id == 0)
                    database.Insert(item);
                else   
                   database.Update(item);
                 return item.Id;
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Soap>(id);
            }
        }
}
    }
