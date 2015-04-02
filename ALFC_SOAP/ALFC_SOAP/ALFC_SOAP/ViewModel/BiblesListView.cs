﻿using ALFC_SOAP.Data;
using ALFC_SOAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP.ViewModel
{
    public class BiblesListView : ListView
    {
        private BibleVersions db = new BibleVersions();

        public BiblesListView ()
	    {
            List<IDataListItem> items = db.GetList();
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.VerticalOptions = LayoutOptions.FillAndExpand;
            
            this.ItemsSource = items;
            this.ItemTemplate = BaseListItemTemplate.Get();
	    }
    }
}
