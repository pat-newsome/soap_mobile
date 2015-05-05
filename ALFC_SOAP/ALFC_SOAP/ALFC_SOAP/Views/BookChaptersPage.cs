using Acr.XamForms.Mobile;
using ALFC_SOAP.Common;
using ALFC_SOAP.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ALFC_SOAP
{
    class BookChaptersPage : ContentPage
    {
        
        public BookChaptersPage(ISettings settings, Book book)
        {
            this.Content = new BookChaptersView(settings, book);
            this.BackgroundColor = AppColors.Blue;
        }

    }

    
}
