using Acr.XamForms.Mobile.IO;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.ViewModel
{
    public class FileSystemViewModel 
    {
        private readonly IFileSystem fileSystem;


        public FileSystemViewModel(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            
        }


        public string AppDataDirectory
        {
            get { return this.fileSystem.AppData.FullName; }
        }


        public string CacheDirectory
        {
            get { return this.fileSystem.Cache.FullName; }
        }


        public string PublicDirectory
        {
            get { return this.fileSystem.Public.FullName; }
        }


        public string TempDirectory
        {
            get { return this.fileSystem.Temp.FullName; }
        }
    }
}
