using DashboardDemo.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksGroupPage : ContentPage
    {
        private TasksPage tasksPage;

        public TasksGroupPage()
        {
            InitializeComponent();
            InitText();
        }

        public TasksGroupPage(TasksPage page)
        {
            InitializeComponent();
            InitText();
            tasksPage = page;
        }

        private void InitText()
        {
            picker.Title = AppResources.PickerTitle;
            btnCancel.Text = AppResources.ButtonCancelText;
        }

        private void OnOKClicked(object sender, EventArgs e)
        {
            if (tasksPage != null && picker.SelectedItem != null)
            {
                tasksPage.SetGridGroupedColumnAsync(picker.SelectedItem.ToString());
            }
            
            Navigation.PopModalAsync(true);
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        public void SetPickerItemsSource(List<string> list)
        {
            picker.ItemsSource = list;
        }

        public void SetPickerSelectedItem(String item)
        {
            if (!String.IsNullOrEmpty(item))
            {
                picker.SelectedItem = item;
            }
        }
    }
}