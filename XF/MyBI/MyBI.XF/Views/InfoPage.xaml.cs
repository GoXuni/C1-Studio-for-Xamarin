using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoPage : ContentPage
	{
		public InfoPage ()
		{
			InitializeComponent ();
            this.Title = MyBI.Resources.AppResources.AboutTitle;
            aboutLabel.Text = MyBI.Resources.AppResources.AboutText;
            powerByLabel.Text = MyBI.Resources.AppResources.PoweredByText;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                Device.OpenUri(new Uri("https://www.grapecity.com/en/componentone-xamarin"));
            };
            powerByLabel.GestureRecognizers.Add(tapGestureRecognizer);
        }
	}
}