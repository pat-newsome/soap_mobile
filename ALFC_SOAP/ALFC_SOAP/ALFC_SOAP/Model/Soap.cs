using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;
namespace ALFC_SOAP.Model
{
    public class Soap : ViewModelBase
    {

        string  observation, scripture, application, prayer;

        
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
                Set(ref scripture, value);
            }
            get { return scripture; }
        }

        public int ReadingId { get; set; }

        public int PlanId { get; set; }

        //public void SaveAsync()
        //{
        //    string text = Identifier() + "|" + this.Scripture + "|" + this.Observation + "|" + this.Application + "|" + this.Prayer;
        //    FileHelper.WriteText(this.Filename, text);
        //}

        //private string Identifier()
        //{
        //    string.Format("{0}_{1}_{}")
        //}

        //public void LoadAsync()
        //{
        //    string text = FileHelper.ReadText(this.Filename);

        //    string[] soaptext = text.Split('|');
        //    if (soaptext.Length > 4)
        //    {
        //        this.Identifier = soaptext[0];
        //        this.Scripture = soaptext[1];
        //        this.Observation = soaptext[2];
        //        this.Application = soaptext[3];
        //        this.Prayer = soaptext[4];
        //    }
        //    else
        //    {
        //        string showText = this.Filename.Substring(0, this.Filename.IndexOf("20")).Replace('_', ' ');
        //        this.Identifier = showText;
        //        this.Scripture = showText;
        //    }
        //}

        //public void DeleteAsync()
        //{
        //    FileHelper.DeleteFile(this.Filename);
        //}



        internal void Save()
        {
            throw new NotImplementedException();
        }
    }
}
