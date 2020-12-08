using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OOP_Lab_3.Annotations;
using OOP_Lab_3.Base;

namespace OOP_Lab_3.Models
{
    [Serializable]
    public class Shipment : ModelBase
    {
        private string _nameOfReceiver;
        private string _country;
        private string _city;
        private string _streetAndHouseNumber;
        private string _flatNumber;

        public string NameOfReceiver
        {
            get => _nameOfReceiver;
            set
            {
                _nameOfReceiver = value;
                OnPropertyChanged(nameof(NameOfReceiver));
            }
        }

        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        public string StreetAndHouseNumber
        {
            get => _streetAndHouseNumber;
            set
            {
                _streetAndHouseNumber = value;
                OnPropertyChanged(nameof(StreetAndHouseNumber));
            }
        }

        public string FlatNumber
        {
            get => _flatNumber;
            set
            {
                _flatNumber = value;
                OnPropertyChanged(nameof(FlatNumber));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
    }
}