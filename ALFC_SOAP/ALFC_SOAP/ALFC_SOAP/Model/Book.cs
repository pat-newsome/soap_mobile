﻿using Acr.XamForms.Mobile;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.Model
{
    public class Book : IDataListItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name
        {
            get;
            set;
        }

        public string Value { get; set; }

        public int ChapterCount
        {
            get;
            set;
        }

        public string OriginalLanguage
        { get; set; }

        public Book(int id, string name, string value, string original, int count)
        {
            
            this.Id = id;
            this.Name = name;
            this.Value = value;
            this.ChapterCount = count;
            this.OriginalLanguage = original;
        }

        public string Url()
        {

            return string.Format("{0}/search?{1}", Constants.SearchURLbase, Name);
        }

        public bool IsSelected
        {
            get { return false; }
        }
    }
}
