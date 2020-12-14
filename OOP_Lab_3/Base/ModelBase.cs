using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using OOP_Lab_3.Annotations;

namespace OOP_Lab_3.Base
{
    [Serializable]
    public abstract class ModelBase : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static string GetIdPropertyName()
        {
            return nameof(Id);
        }
    }
}