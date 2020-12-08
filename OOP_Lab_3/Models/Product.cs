using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OOP_Lab_3.Annotations;
using OOP_Lab_3.Base;

namespace OOP_Lab_3.Models
{
    [Serializable]
    public class Product : ModelBase
    {
        private string _name;
        private float _price;
        private int _quantity;
        private float _weight;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public float Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
    }
}