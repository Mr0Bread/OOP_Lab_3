using System;
using OOP_Lab_3.Base;
using OOP_Lab_3.Constants;
using OOP_Lab_3.Events;

namespace OOP_Lab_3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private BindableBase _currentViewModel;
        private MainMenuViewModel _mainMenuViewModel = new MainMenuViewModel();

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = new SignInViewModel();
            SignInEvent.HandleSignIn = HandleSignIn;
            NavigationEvent.HandleNavigation += HandleNavigation;
        }

        private void HandleSignIn(bool isSignedInd)
        {
            if (isSignedInd)
            {
                CurrentViewModel = _mainMenuViewModel;
            }
        }

        private void HandleNavigation(string destination)
        {
            switch (destination)
            {
                case NavDestination.Order:
                    break;
                case NavDestination.Orders:
                    break;
                case NavDestination.Product:
                    break;
                case NavDestination.Products:
                    break;
                case NavDestination.Customer:
                    break;
                case NavDestination.Customers:
                    break;
                case NavDestination.User:
                    break;
                case NavDestination.Users:
                    break;
                case NavDestination.Shipment:
                    break;
                case NavDestination.Shipments:
                    break;
            }
        }
    }
}