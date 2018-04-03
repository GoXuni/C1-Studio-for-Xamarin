using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace C1CollectionView101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Xamarin.Forms.NavigationPage(new CollectionViewSamples()) { BarBackgroundColor = Color.FromHex("#9E9E9E"), BarTextColor = Color.White };
        }

        protected override void OnStart()
        {

        }
    }
}
