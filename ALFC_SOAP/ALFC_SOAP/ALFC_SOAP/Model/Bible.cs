﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALFC_SOAP.Model
{
    public class Bible : IDataListItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        { get; set; }

        public string Name
        { get; set; }

        public string Value
        { get; set; }


    }
}
