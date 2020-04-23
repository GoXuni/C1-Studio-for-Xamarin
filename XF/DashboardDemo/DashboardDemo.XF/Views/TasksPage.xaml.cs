using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardModel;
using DashboardDemo.ViewModels;
using DashboardDemo.Resources;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksPage : ContentPage
    {
        TasksViewModel model;
        TasksGroupPage groupPage;

        public TasksPage()
        {
            InitializeComponent();
            InitText();

            model = new TasksViewModel();
            model.PropertyChanged += OnVMPropertyChanged;
            groupPage = new TasksGroupPage(this);

            this.BindingContext = model;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    {
                        ToolbarItems.Remove(btnMonthData);
                        ToolbarItems.Remove(btn3MonthsData);
                        ToolbarItems.Remove(btn6MonthsData);
                        ToolbarItems.Remove(btnYearData);
                        ToolbarItems.Remove(btn2YearsData);

                        this.ToolbarItems.Add(new ToolbarItem(AppResources.ToolbarFilterText, "", () => { OnFilterClick(); }, 0, 0));
                    }
                    break;
                case Device.UWP:
                    if (Device.Idiom == TargetIdiom.Desktop)
                    {
                        CompleteColumn.Width = GridLength.Star;
                    }
                    else
                    {
                        CompleteColumn.Width = GridLength.Auto;
                    }
                    break;
            }
            SetGridGroupedColumnAsync("AssignTo");
            groupPage.SetPickerSelectedItem("AssignTo");
        }

        private void InitText()
        {
            Title = AppResources.TasksTitle;
            btnEditColumnLayout.Text = AppResources.ButtonEditColumnLayoutText;
            btnMonthData.Text = AppResources.FilterMonthText;
            btn3MonthsData.Text = AppResources.Filter3MonthsText;
            btn6MonthsData.Text = AppResources.Filter6MonthsText;
            btnYearData.Text = AppResources.FilterYearText;
            btn2YearsData.Text = AppResources.Filter2YearsText;
            AllTasks.Text = AppResources.ButtonAllTasksText;
            InProgress.Text = AppResources.ButtonInProgressText;
            Completed.Text = AppResources.ButtonCompletedText;
            Deffered.Text = AppResources.ButtonDefferedText;
            Urgent.Text = AppResources.ButtonUrgentText;
        }

        private void OnVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Tasks")
            {
                gridTasks.ItemsSource = model.Tasks;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await model.FilterMonthDataAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        public async void SetGridGroupedColumnAsync(string column)
        {
            if (model.GroupName != column)
            {
                await model.GroupTasks(column);
                gridTasks.ShowOutlineBar = true;
            }
        }

        private async void OnFilterClick()
        {
            var action = await DisplayActionSheet(AppResources.FilterOptionsText, AppResources.FilterCancelText, null, AppResources.FilterMonthText,
                AppResources.Filter3MonthsText, AppResources.Filter6MonthsText, AppResources.FilterYearText, AppResources.Filter2YearsText);

            if (action == AppResources.FilterMonthText)
            {
                await model.FilterMonthDataAsync();
            }
            else if (action == AppResources.Filter3MonthsText)
            {
                await model.Filter3MonthsDataAsync();
            }
            else if (action == AppResources.Filter6MonthsText)
            {
                await model.Filter6MonthsDataAsync();
            }
            else if (action == AppResources.FilterYearText)
            {
                await model.FilterYearDataAsync();
            }
            else if (action == AppResources.Filter2YearsText)
            {
                await model.Filter2YearsDataAsync();
            }
        }

        private void OnEditColumnLayout(object sender, EventArgs e)
        {
            var columnsList = new List<string>();

            foreach (var p in typeof(CampainTaskItem).GetRuntimeProperties())
            {
                if (p.Name != "saleData" && p.Name != "Deferred" && p.Name != "Urgent")
                {
                    columnsList.Add(p.Name);
                }
            }

            groupPage.SetPickerItemsSource(columnsList);
            groupPage.SetPickerSelectedItem(model.GroupName);
            Navigation.PushModalAsync(groupPage, true);
        }

        private async void OnAllTasks(object sender, EventArgs e)
        {
            await model.FilterAllTasksAsync();
            AllTasks.BackgroundColor = Color.FromHex("#790F19");
            InProgress.BackgroundColor = Color.FromHex("#051839");
            Completed.BackgroundColor = Color.FromHex("#051839");
            Urgent.BackgroundColor = Color.FromHex("#051839");
            Deffered.BackgroundColor = Color.FromHex("#051839");
        }

        private async void OnInProgress(object sender, EventArgs e)
        {
            await model.FilterInProgressTasksAsync();
            AllTasks.BackgroundColor = Color.FromHex("#051839");
            InProgress.BackgroundColor = Color.FromHex("#790F19");
            Completed.BackgroundColor = Color.FromHex("#051839");
            Urgent.BackgroundColor = Color.FromHex("#051839");
            Deffered.BackgroundColor = Color.FromHex("#051839");
        }

        private async void OnCompleted(object sender, EventArgs e)
        {
            await model.FilterCompletedTasksAsync();
            AllTasks.BackgroundColor = Color.FromHex("#051839");
            InProgress.BackgroundColor = Color.FromHex("#051839");
            Completed.BackgroundColor = Color.FromHex("#790F19");
            Urgent.BackgroundColor = Color.FromHex("#051839");
            Deffered.BackgroundColor = Color.FromHex("#051839");
        }

        private async void OnDeferred(object sender, EventArgs e)
        {
            await model.FilterDeferredTasksAsync();
            AllTasks.BackgroundColor = Color.FromHex("#051839");
            InProgress.BackgroundColor = Color.FromHex("#051839");
            Completed.BackgroundColor = Color.FromHex("#051839");
            Urgent.BackgroundColor = Color.FromHex("#051839");
            Deffered.BackgroundColor = Color.FromHex("#790F19");

        }

        private async void OnUrgent(object sender, EventArgs e)
        {
            await model.FilterUrgentTasksAsync();
            AllTasks.BackgroundColor = Color.FromHex("#051839");
            InProgress.BackgroundColor = Color.FromHex("#051839");
            Completed.BackgroundColor = Color.FromHex("#051839");
            Deffered.BackgroundColor = Color.FromHex("#051839");
            Urgent.BackgroundColor = Color.FromHex("#790F19");
        }

        private async void OnMonthData(object sender, EventArgs e)
        {
            await model.FilterMonthDataAsync();
        }

        private async void On3MonthsData(object sender, EventArgs e)
        {
            await model.Filter3MonthsDataAsync();
        }

        private async void On6MonthsData(object sender, EventArgs e)
        {
            await model.Filter6MonthsDataAsync();
        }

        private async void OnYearData(object sender, EventArgs e)
        {
            await model.FilterYearDataAsync();
        }

        private async void On2YearsData(object sender, EventArgs e)
        {
            await model.Filter2YearsDataAsync();
        }
    }
}