using Java.IO;
using System;
using System.Collections.Generic;
//using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ALFC_SOAP.Droid.FileHelper))]

namespace ALFC_SOAP.Droid
{
    
    class FileHelper : IFileHelper
    {
        public Task<bool> ExistsAsync(string filename)
        {
            string filepath = GetFilePath(filename);
            File file = new File(filepath);
            bool exists = file.Exists();
            return Task<bool>.FromResult(exists);
        }

        public async Task WriteTextAsync(string filename, string text)
        {
            string filepath = GetFilePath(filename);
            File file = new File(filepath);
            try
            {
                if (!file.Exists())
                    file.CreateNewFile();

            }
            catch { }
            using (BufferedWriter writer = new BufferedWriter(new FileWriter(file, true)))
            {
                await writer.WriteAsync(text);
                await writer.FlushAsync();
                writer.Close();
            }
            //using (StreamWriter writer = File.CreateText(filepath))
            //{
            //    await writer.WriteAsync(text);
            //}
        }

        public async Task<string> ReadTextAsync(string filename)
        {
            string filepath = GetFilePath(filename);
            string text = "";
            File file = new File(filepath);
            if(file.Exists())
            {
                char current;
                FileInputStream  stream = new FileInputStream(file);
                while(stream.Available() > 0)
                {
                    current = (char)stream.Read();
                    text += current.ToString();
                }

            }
            return text;
        }

        public Task<IEnumerable<string>> GetFilesAsync()
        {
            File file = new File(GetDocsFolder());
            List<string> filenames = new List<string>();
            string[] files = file.List();
            if(files != null)
            for (int i = 0; i < files.Length; i++)
			{
                filenames.Add(files[i]); 
			}
            
            
            // Sort the filenames.
            //IEnumerable<string> filenames = 
            //    from filepath in Directory.EnumerateFiles(GetDocsFolder())
            //    select Path.GetFileName(filepath);

            return Task<IEnumerable<string>>.FromResult((IEnumerable<string>)filenames);
        }

        public Task DeleteFileAsync(string filename)
        {
            string filepath = GetFilePath(filename);
            File file = new File(filepath);
            file.Delete();
            
            return Task.FromResult(true);
        }

        string GetDocsFolder()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return path;
        }

        string GetFilePath(string filename)
        {
            return String.Concat(GetDocsFolder(), "/",filename);
        }
    }
}