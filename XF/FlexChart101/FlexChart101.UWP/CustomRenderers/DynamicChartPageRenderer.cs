using FlexChart101;
using FlexChart101.UWP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(DynamicChartsSample), typeof(DynamicChartPageRenderer))]
namespace FlexChart101.UWP
{
    public class DynamicChartPageRenderer : PageRenderer
    {
        Windows.UI.Xaml.Application _app;
        DynamicChartsSample XElement;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            XElement = e.NewElement as DynamicChartsSample;

            try
            {
                _app = Application.Current;
                _app.Suspending += Suspending;
                _app.Resuming += Resuming;
                _app.EnteredBackground += EnteredBackground;
                _app.LeavingBackground += LeavingBackground;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: ", ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _app.Suspending -= Suspending;
            _app.Resuming -= Resuming;
            _app.EnteredBackground -= EnteredBackground;
            _app.LeavingBackground -= LeavingBackground;

            XElement?.CancelTimer();
            XElement = null;
        }

        private void LeavingBackground(object sender, Windows.ApplicationModel.LeavingBackgroundEventArgs e)
        {
            XElement.StartTimer();
        }

        private void EnteredBackground(object sender, Windows.ApplicationModel.EnteredBackgroundEventArgs e)
        {
            XElement.CancelTimer();
        }

        private void Resuming(object sender, object e)
        {
            XElement.StartTimer();
        }

        private void Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            XElement.CancelTimer();
        }
    }
}
