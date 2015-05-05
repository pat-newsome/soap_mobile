using Xamarin.Forms;
using SQLite.Net.Attributes;

namespace ALFC_SOAP.Model
{
    public class Reading : IDataListItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        public int PlanId
        {
            get;
            set;
        }

        public int BookId { get; set; }

        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string UrlSearch { get { return string.Format("{0} {1}", Name, Value); } }

        public bool HaveRead { get; set; }

        public ImageSource StatusImage 
        {
            get
            { 
                return HaveRead ? Device.OnPlatform(ImageSource.FromFile("Images/actionChecked.png"), ImageSource.FromFile("actionChecked.png"), ImageSource.FromFile("Images/actionChecked.png")) : Device.OnPlatform(ImageSource.FromFile("Images/actionUnChecked.png"), ImageSource.FromFile("actionUnChecked.png"), ImageSource.FromFile("Images/actionUnChecked.png"));}
            }
    }
}
