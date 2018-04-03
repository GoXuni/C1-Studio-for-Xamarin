using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashboardDemo.ViewModels
{
    public class MasterPageItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }

        public ImageSource Icon
        {
            get
            {
                return ImageSource.FromResource("DashboardDemo.Images." + IconSource, typeof(App));
            }
        }
    }
}
