using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP
{
    public class SoapFolder
    {
        public SoapFolder()
        {
            this.SoapMessages = new ObservableCollection<Soap>();
            GetFilesAsync();
        }

        public ObservableCollection<Soap> SoapMessages { private set; get; }

        async void GetFilesAsync()
        {
            // Sort the filenames.
            IEnumerable<string> filenames =
                from filename in await FileHelper.GetFilesAsync()
                where filename.EndsWith(".soap")
                orderby (filename)
                select filename;

            // Store them in the Notes collection.
            foreach (string filename in filenames)
            {
                Soap soapmessage = new Soap(filename);
                await soapmessage.LoadAsync();
                this.SoapMessages.Add(soapmessage);
            }
        }
    }
}
