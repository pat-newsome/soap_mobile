using Acr.XamForms.Mobile.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace ALFC_SOAP
{

    static class FileHelper
    {
        static IFileSystem fileHelper = DependencyService.Get<IFileSystem>();
        static IDirectory dir;

        public static bool Exists(string filename)
        {
            SetDirectory();
            //var dir = fileHelper.GetDirectory(fileHelper.AppData.FullName + "/SoapFactory");
            return dir.FileExists(filename);
        }

        public static void WriteText(string filename, string text)
        {
            SetDirectory();
      
            var fe = dir.FileExists(filename);
            var file = fe ? dir.GetExistingFile(filename) : dir.CreateFile(filename);

            using(StreamWriter sw = new StreamWriter(file.OpenWrite()))
            {
                sw.Write(text);
                sw.Flush();
            }
        }

        public static string ReadText(string filename)
        {
            SetDirectory();
            var file = dir.GetFile(filename);
            string soapText = "";
            using (Stream stream = file.OpenRead())
            {
                byte[] bytes = new byte[file.Length];
                stream.ReadAsync(bytes, 0, (int)file.Length);
                soapText = System.Text.Encoding.UTF8.GetString(bytes, 0, (int)file.Length);
            }
            return soapText;
        }

        public static IEnumerable<IFile> GetFiles()
        {
            SetDirectory();
            var list = dir.Files;
            return list;
        }

        public static void DeleteFile(string filename)
        {
            SetDirectory();
            //var dir = fileHelper.GetDirectory(fileHelper.AppData.FullName + "/SoapFactory");
            var file = dir.GetFile(filename);
            if(file.Exists)
            file.Delete();
        }

        private static void SetDirectory()
        {
            dir = fileHelper.GetDirectory(fileHelper.Public.FullName + "/SoapFactory");
        }
    }
}
