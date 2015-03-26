using Acr.XamForms.Mobile.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.Model
{
    public class SoapFolder
    {
        private IFileSystem fileSystem;

        public SoapFolder(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            this.SoapMessages = new ObservableCollection<Soap>();
            GetFilesAsync();
        }

        public ObservableCollection<Soap> SoapMessages { private set; get; }

        async void GetFilesAsync()
        {
            //TODO: Refactor this
            //var listSoaps = fileSystem.Public.Files.SelectMany();
            //// Sort the filenames.
            //IEnumerable<string> filenames =
            //    from filename in fileSystem.Public.Files.
            //    where filename.EndsWith(".soap")
            //    orderby (filename)
            //    select filename;

            //// Store them in the Notes collection.
            //foreach (string filename in filenames)
            //{
            //    Soap soapmessage = new Soap(filename);
            //    await soapmessage.LoadAsync();
            //    this.SoapMessages.Add(soapmessage);
            //}
        }
    }
}
