using ALFC_SOAP.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP.Data
{
    public class PlansData
    {

        static object locker = new object();

        SQLiteConnection database;

        public PlansData()
        {
            //readingplan = new List<Reading>();

            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<ReadingPlan>();
        }

        public IEnumerable<ReadingPlan> GetItems()
        {
            lock (locker)
            {
                return database.Query<ReadingPlan>(string.Format("SELECT * FROM [ReadingPlan]"));
            }
        }

        public ReadingPlan GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<ReadingPlan>().FirstOrDefault(x => x.Id == id);
            }
        }
        public ReadingPlan GetSelected()
        {
            lock (locker)
            {
                return database.Table<ReadingPlan>().FirstOrDefault(x => x.IsSelected == true);
            }
        }

        public int SaveItem(ReadingPlan item)
        {
            lock (locker)
            {
                if(item.IsSelected)
                {
                    database.Query<ReadingPlan>("Update [ReadingPlan] SET IsSelected = 0");
                }
                if (item.Id != 0)
                {
                      //database.Query<ReadingPlan>(string.Format("Update [ReadingPlan] SET IsSelected = {0}, Name = '{1}', Value='{2}' WHERE Id = {3}", item.IsSelected? 1:0, item.Name, item.Value, item.Id));
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
                return database.Delete<ReadingPlan>(id);
            }
        }
    }
}
