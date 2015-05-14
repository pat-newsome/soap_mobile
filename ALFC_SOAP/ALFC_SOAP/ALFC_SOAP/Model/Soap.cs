using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;
using ALFC_SOAP.Data;
namespace ALFC_SOAP.Model
{
    public class Soap : ViewModelBase
    {

        string observation, scripture, application, prayer, identifier;

        
        public Soap()
        {
            
        }

        public Soap(string scripture)
        {
            
            this.Scripture = scripture;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

       
        public string Application
        {
            set
            {
                Set(ref application, value);
                
            }
            get { return application; }
        }

        public string Observation
        {
            set
            {
                Set(ref observation, value);
            }
            get { return observation; }
        }

        public string Prayer
        {
            set
            {
                Set(ref prayer, value);
            }
            get { return prayer; }
        }

        public string Scripture
        {
            set
            {
                Set(ref scripture, value.TrimStart());
                SetIdentifier();
            }
            get { return scripture; }
        }

        

        public string Identifier
        {
            set
            {
                Set(ref identifier, value);
            }
            get { return identifier; }
        }

        public int ReadingId { get; set; }

        public int PlanId { get; set; }

        public void Save()
        {
            SOAPData db = new SOAPData();
            db.SaveItem(this);
        }

        private void SetIdentifier()
        {
            var endPosition = Scripture.IndexOf(' ', Scripture.IndexOf(' ') + 1);
            endPosition = endPosition <= 0 ? Scripture.Length : endPosition;
            Identifier = Scripture.Substring(0, endPosition);
        }

        public void Delete()
        {
            SOAPData db = new SOAPData();
            db.DeleteItem(Id);
        }
    }
}
