﻿using C1Calendar101.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;
using C1.Xamarin.Forms.Calendar;
using Xamarin.Forms;

namespace C1Calendar101
{
    public partial class DatePicker : ContentPage
    {
        private TaskCompletionSource<DateTime> _completion;

        public DatePicker()
        {
            InitializeComponent();
            Title = AppResources.PickDateLabel;
        }

        protected override bool OnBackButtonPressed()
        {
            if (_completion != null)
                _completion.TrySetCanceled();
            return base.OnBackButtonPressed();
        }

        private async void OnSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            if (e.SelectedDates!=null && e.SelectedDates.Count > 0)
            {
                await Task.Delay(100);
                await Navigation.PopModalAsync(true);
                _completion.TrySetResult(e.SelectedDates.First());
            }

        }

        public static async Task<DateTime> PickDateAsync(INavigation navigation)
        {
            var picker = new DatePicker();
            picker._completion = new TaskCompletionSource<DateTime>();
            await navigation.PushModalAsync(picker, true);
            return await picker._completion.Task;
        }
    }
}
