using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

namespace DashboardDemo.UWP
{
    public class DefaultButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.Template = Windows.UI.Xaml.Application.Current.Resources["DefaultButtonControlTemplate"] as Windows.UI.Xaml.Controls.ControlTemplate;
            }
        }
    }
}
