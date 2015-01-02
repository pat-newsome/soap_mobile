using ALFC_SOAP.Common;
using ALFC_SOAP.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    class BookChaptersPage : ContentPage
    {
        
        public BookChaptersPage(Book book)
        {

            this.Content = new BookChaptersView(book);
            this.BackgroundColor = AppColors.Blue;
        }

    }

    
}
