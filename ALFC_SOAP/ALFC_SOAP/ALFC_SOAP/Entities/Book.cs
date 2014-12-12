using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.Entities
{
    class Book
    {
        public string Name
        {
            get;
            set;
        }

        public int ChapterCount
        {
            get;
            set;
        }

        public string OriginalLanguage
        { get; set; }

        public Book(string name, string original, int count)
        {
            this.Name = name;
            this.ChapterCount = count;
            this.OriginalLanguage = original;
        }
        public string Url()
        {
            return string.Format("www.biblegateway.com/search?{0}" + Name);
        }
    }
}
