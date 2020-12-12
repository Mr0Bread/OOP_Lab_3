using System;
using OOP_Lab_3.Base;
using OOP_Lab_3.Constants;

namespace OOP_Lab_3.ViewModels
{
    public class MainMenuViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }

        public MainMenuViewModel()
        {
            NavCommand = new MyICommand<string>(OnNavigation);
        }

        private void OnNavigation(string destination)
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