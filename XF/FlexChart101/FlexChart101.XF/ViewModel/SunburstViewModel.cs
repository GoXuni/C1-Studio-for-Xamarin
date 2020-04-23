using System.Collections.Generic;
using System.ComponentModel;

namespace FlexChart101
{
    public class SunburstViewModel : INotifyPropertyChanged
    {
        private string _legendPosition = "Auto";
        private string _selectedItemPosition = "Top";

        public List<SunburstDataItem> HierarchicalData
        {
            get
            {
                return DataService.CreateHierarchicalData();
            }
        }

        public List<FlatDataItem> FlatData
        {
            get
            {
                return DataService.CreateFlatData();
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
