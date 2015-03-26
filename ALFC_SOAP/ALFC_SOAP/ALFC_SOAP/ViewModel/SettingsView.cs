using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.XamForms.Mobile;

namespace ALFC_SOAP.ViewModel
{
    public class SettingsView
    {
        private ISettings currentSettings;

        public SettingsView(ISettings settings)
        {
            this.currentSettings = settings;
        }
    }
}
