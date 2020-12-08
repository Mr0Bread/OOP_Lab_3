using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OOP_Lab_3.Annotations;
using OOP_Lab_3.Base;

namespace OOP_Lab_3.Models
{
    [Serializable]
    public class Customer : ModelBase
    {
        private string _name;
        private string _surname;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public object this[string propertyName]
        {
            get
            {
                var type = typeof(Customer);
                var myPropInfo = type.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                var type = typeof(Customer);
                var myPropInfo = type.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
        }
    }
}