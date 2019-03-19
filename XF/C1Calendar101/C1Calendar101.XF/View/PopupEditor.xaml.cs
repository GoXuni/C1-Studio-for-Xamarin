using System;
using C1Calendar101.Resources;
using Xamarin.Forms.Xaml;

namespace C1Calendar101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupEditor
    {
        public PopupEditor()
        {
            InitializeComponent();
            Title = AppResources.PopupEditorTitle;
        }

        public async void OnSelectDateClicked(object sender, EventArgs e)
        {
            try
            {
                var date = await DatePicker.PickDateAsync(Navigation);
                message.Text = string.Format(AppResources.SelectedDateMessage, date);
            }
            catch (OperationCanceledException)
            {
                message.Text = "";
            }
        }


        public string PickDateLabel
        {
            get
            {
                return AppResources.PickDateLabel;
            }
        }
    }
}
