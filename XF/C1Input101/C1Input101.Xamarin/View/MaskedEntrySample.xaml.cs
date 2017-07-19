using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1Input101.Resources;

namespace C1Input101
{
    public partial class MaskedEntrySample
    {
        public MaskedEntrySample()
        {
            InitializeComponent();
            Title = AppResources.MaskedEntryTitle;
            //c1MaskedTextBox1.Mask = "90/90/0000";

        }
        public string IDText
        {
            get
            {
                return AppResources.ID;
            }

        }
        public string DOBText
        {
            get
            {
                return AppResources.DOB;
            }
        }
        public string PhoneText
        {
            get
            {
                return AppResources.Phone;
            }
        }
        public string StateText
        {
            get
            {
                return AppResources.State;
            }
        }
    }
}
