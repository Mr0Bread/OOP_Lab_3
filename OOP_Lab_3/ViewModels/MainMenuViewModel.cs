using System;
using OOP_Lab_3.Base;
using OOP_Lab_3.Constants;
using OOP_Lab_3.Events;

namespace OOP_Lab_3.ViewModels
{
    public class MainMenuViewModel : BindableBase
    {
        private BindableBase _currentMainMenuViewModel;

        public BindableBase CurrentMainMenuViewModel
        {
            get => _currentMainMenuViewModel;
            set
            {
                _currentMainMenuViewModel = value;
                OnPropertyChanged(nameof(CurrentMainMenuViewModel));
            }
        }

        public MyICommand<string> NavCommand { get; private set; }

        public MainMenuViewModel()
        {
            NavCommand = new MyICommand<string>(OnNavigation);
        }

        private void OnNavigation(string destination)
        {
           NavigationEvent.GoTo(destination);
        }
    }
}