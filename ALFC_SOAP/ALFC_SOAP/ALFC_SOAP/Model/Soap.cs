using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ALFC_SOAP.Model
{
    public class Soap : ViewModelBase
    {
        string  observation, identifier, scripture, application, prayer;

        
        public Soap(string filename)
        {
            this.Filename = filename.Trim().Replace(" ", "_");
        }

        public Soap(string filename, string scripture)
        {
            this.Filename = filename.Trim().Replace(" ", "_");
            this.Scripture = scripture;
        }

        public string Filename { private set; get; }

        public string Application
        {
            set
            {
                if (Set(ref application, value))
                {
                    this.Identifier = MakeIdentifier();
                }
            }
            get { return application; }
        }

        public string Observation
        {
            set
            {
                if (Set(ref observation, value) &&
                    String.IsNullOrWhiteSpace(this.Observation))
                {
                    this.Identifier = MakeIdentifier();
                }
            }
            get { return observation; }
        }

        public string Prayer
        {
            set
            {
                if (Set(ref prayer, value) &&
                    String.IsNullOrWhiteSpace(this.Prayer))
                {
                    this.Identifier = MakeIdentifier();
                }
            }
            get { return prayer; }
        }

        public string Scripture
        {
            set
            {
                if (Set(ref scripture, value) &&
                    String.IsNullOrWhiteSpace(this.Scripture))
                {
                    this.Identifier = MakeIdentifier();
                }
            }
            get { return scripture; }
        }

        public string Identifier
        {
            private set { Set(ref identifier, value); }
            get { return identifier; }
        }

        string MakeIdentifier()
        {
            if (!String.IsNullOrWhiteSpace(this.Scripture))
                return this.Scripture;

            int truncationLength = 30;

            if (this.Observation == null ||
                this.Observation.Length <= truncationLength)
            {
                return this.Observation;
            }

            string truncated =
                this.Observation.Substring(0, truncationLength);

            int index = truncated.LastIndexOf(' ');

            if (index != -1)
                truncated = truncated.Substring(0, index);

            return truncated;
        }

        public void SaveAsync()
        {
            string text = this.Identifier + "|" + this.Scripture + "|" + this.Observation + "|" + this.Application + "|" + this.Prayer;
            FileHelper.WriteText(this.Filename, text);
        }

        public void LoadAsync()
        {
            string text = FileHelper.ReadText(this.Filename);

            string[] soaptext = text.Split('|');
            if (soaptext.Length > 4)
            {
                this.Identifier = soaptext[0];
                this.Scripture = soaptext[1];
                this.Observation = soaptext[2];
                this.Application = soaptext[3];
                this.Prayer = soaptext[4];
            }
            else
            {
                string showText = this.Filename.Substring(0, this.Filename.IndexOf("20")).Replace('_', ' ');
                this.Identifier = showText;
                this.Scripture = showText;
            }
        }

        public void DeleteAsync()
        {
            FileHelper.DeleteFile(this.Filename);
        }

        
    }
}
