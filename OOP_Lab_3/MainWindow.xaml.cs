using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OOP_Lab_3.Constants;
using OOP_Lab_3.Models;
using OOP_Lab_3.Navigation;
using OOP_Lab_3.Storage.StorageManagers;
using OOP_Lab_3.ViewModels;

namespace OOP_Lab_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeApplication();
        }

        private async void InitializeApplication()
        {
            await InitializeNavigation();
            await InitializeStorage();
        }

        private async Task InitializeStorage()
        {
            await Task.Run(Storage.Storage.InitializeStorage);
        }

        private async Task InitializeNavigation()
        {
            await Task.Run(() =>
            {
                Navigation.Navigation.Pages = new List<View>
                {
                    new View(NavDestination.MainMenu, nameof(MainMenuViewModel)),
                    new View(NavDestination.Users, nameof(UsersViewModel)),
                    new View(NavDestination.SignIn, nameof(SignInViewModel))
                };
            });
        }
    }
}