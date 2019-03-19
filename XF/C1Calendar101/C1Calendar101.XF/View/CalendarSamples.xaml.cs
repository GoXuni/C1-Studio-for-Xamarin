﻿using C1Calendar101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C1Calendar101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarSamples : ContentPage
    {
        public CalendarSamples()
        {
            InitializeComponent();

            Title = "C1Calendar101";

            BindingContext = GetSamples();
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.GettingStartedTitle, Description = AppResources.GettingStartedDescription, SampleViewType = 1 , Thumbnail = "calendar.png" },
                new Sample() { Name = AppResources.VerticalOrientationTitle, Description = AppResources.VerticalOrientationDescription, SampleViewType = 2 , Thumbnail = "calendar_vertical.png" },
                new Sample() { Name = AppResources.CustomDayContentTitle, Description = AppResources.CustomDayContentDescription, SampleViewType = 3 , Thumbnail = "calendar2.png" },
                new Sample() { Name = AppResources.CustomHeaderTitle, Description = AppResources.CustomHeaderDescription, SampleViewType = 4 , Thumbnail = "calendar.png" },
                new Sample() { Name = AppResources.CustomAppearanceTitle, Description = AppResources.CustomAppearanceDescription, SampleViewType = 5 , Thumbnail = "calendar.png" },
                new Sample() { Name = AppResources.PopupEditorTitle, Description = AppResources.PopupEditorDescription, SampleViewType = 6 , Thumbnail = "calendar_datepicker.png" },
                new Sample() { Name = AppResources.CustomSelectionTitle, Description = AppResources.CustomSelectionDescription, SampleViewType = 7 , Thumbnail = "calendar2.png" },
            };
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                listView.IsEnabled = false;
                var sample = e.Item as Sample;
                await this.Navigation.PushAsync(GetSample(sample.SampleViewType));
            }
            finally
            {
                listView.IsEnabled = true;
            }
        }

        private Page GetSample(int sampleViewType)
        {
            switch (sampleViewType)
            {
                case 1: return new GettingStarted();
                case 2: return new VerticalOrientation();
                case 3: return new CustomDayContent();
                case 4: return new CustomHeader();
                case 5: return new CustomAppearance();
                case 6: return new PopupEditor();
                case 7: return new CustomSelection();
            }
            return null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}
