using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using C1.DataCollection;

namespace Sunburst101
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

        public C1DataCollection<Item> View
        {
            get
            {
                return DataService.CreateGroupDataCollection();
            }
        }

        //public List<string> Positions
        //{
        //    get
        //    {
        //        return Enum.GetNames(typeof(Position)).ToList();
        //    }
        //}

        //public List<string> Palettes
        //{
        //    get
        //    {
        //        return Enum.GetNames(typeof(Palette)).ToList();
        //    }
        //}

        //public string LegendPosition
        //{
        //    get { return _legendPosition; }
        //    set
        //    {
        //        if (_legendPosition != value)
        //        {
        //            _legendPosition = value;
        //            OnPropertyChanged("LegendPosition");
        //        }
        //    }
        //}

        //public string SelectedItemPosition
        //{
        //    get { return _selectedItemPosition; }
        //    set
        //    {
        //        if (_selectedItemPosition != value)
        //        {
        //            _selectedItemPosition = value;
        //            OnPropertyChanged("SelectedItemPosition");
        //        }
        //    }
        //}

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
