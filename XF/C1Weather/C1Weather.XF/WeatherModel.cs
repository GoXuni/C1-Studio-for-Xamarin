using System.ComponentModel;
using System.Reflection;
using System;
using Xamarin.Forms;

namespace C1Weather
{
    class WeatherModel : INotifyPropertyChanged, IEditableObject
    {
        double _hightemp;
        double _lowtemp;
        double _pressure;
        string _icon;
        int _humidity;
        string _description;
        DateTime _date;
        ImageSource _iconImageSource;

        public WeatherModel()
        {

        }
        public double hightemp
        {
            get { return _hightemp; }
            set
            {
                if (value != _hightemp)
                {
                    _hightemp = value;
                    OnPropertyChanged("hightemp");
                }
            }
        }
        public double lowtemp
        {
            get { return _lowtemp; }
            set
            {
                if (value != _lowtemp)
                {
                    _lowtemp = value;
                    OnPropertyChanged("lowtemp");
                }
            }
        }
        public double pressure
        {
            get { return _pressure; }
            set
            {
                if (value != _pressure)
                {
                    _pressure = value;
                    OnPropertyChanged("pressure");
                }
            }
        }
        public int humidity
        {
            get { return _humidity; }
            set
            {
                if (value != _humidity)
                {
                    _humidity = value;
                    OnPropertyChanged("humidity");
                }
            }
        }
        public DateTime date
        {
            get { return _date; }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    OnPropertyChanged("date");
                }
            }
        }
        public string description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("description");
                }
            }
        }
        public string icon
        {
            get { return _icon; }
            set
            {
                if (value != _icon)
                {
                    _icon = value;
                    OnPropertyChanged("icon");
                }
            }
        }
        public ImageSource IconImageSource
        {
            get
            {
                if (_iconImageSource == null)
                {
                    _iconImageSource = ImageSource.FromUri(new Uri(icon));
                }

                return _iconImageSource;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        WeatherModel _clone;
        public void BeginEdit()
        {
            _clone = (WeatherModel)this.MemberwiseClone();
        }

        public void EndEdit()
        {
            _clone = null;
        }

        public void CancelEdit()
        {
            if (_clone != null)
            {
                foreach (var p in this.GetType().GetRuntimeProperties())
                {
                    if (p.CanRead && p.CanWrite)
                    {
                        p.SetValue(this, p.GetValue(_clone, null), null);
                    }
                }
            }
        }
    }
}
