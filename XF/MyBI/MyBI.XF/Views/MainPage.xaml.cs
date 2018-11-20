using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Model.Instance.Install();
            this.Title = "MyBI";
        }
    }
}