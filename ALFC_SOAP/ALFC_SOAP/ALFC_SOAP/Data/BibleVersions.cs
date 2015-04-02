using ALFC_SOAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.Data
{
    public class BibleVersions : IDataInfo
    {
        string bible = "New International Version, NIV, 1; 21st Centruy King James Version, KJ21, KJ21; American Standard Version, ASV, ASV;Amplified Bible, AMP, AMP; Common English Bible, CEB, CEB;King James Version, KJV, KJV";
        string[] versions;
        List<IDataListItem> booklist;

        public BibleVersions()
        {
            versions = bible.Split(';');
            booklist = new List<IDataListItem>();
            BuildVersionList();
        }

        private void BuildVersionList()
        {
            for (int i = 0; i < versions.Length; i++)
            {
                string[] bookinfo = versions[i].Split(',');
                booklist.Add(new Bible { Id = i, Name = bookinfo[0], Value = bookinfo[1] });
            }
        }
        
        public  List<IDataListItem> GetList()
        {
            return booklist;
        }
    }
}
