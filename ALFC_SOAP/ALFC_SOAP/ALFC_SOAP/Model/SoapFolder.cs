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
        private IDirectory dir;
        public SoapFolder(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            this.SoapMessages = new ObservableCollection<Soap>();
            SetDirectory();
            GetFilesAsync();
        }

        private void SetDirectory()
        {
            dir = fileSystem.GetDirectory(fileSystem.Public.FullName + "/SoapFactory");

            if (!dir.Exists)
            {
                var soapdir = "SoapFactory";
                fileSystem.Public.CreateSubdirectory(soapdir);
            }
        }

        public void Refresh()
        {
            this.SoapMessages = new ObservableCollection<Soap>();
            SetDirectory();
            GetFilesAsync();
        }
        public ObservableCollection<Soap> SoapMessages { private set; get; }

        async void GetFilesAsync()
        {
            
            IEnumerable<IFile> files = dir.Files.Where(f => f.Name.EndsWith(".soap"));
            
            foreach (var file in files)
            {
                Soap soapmessage = new Soap(file.Name);
                soapmessage.LoadAsync();
                this.SoapMessages.Add(soapmessage);
            }
        }
    }
}
