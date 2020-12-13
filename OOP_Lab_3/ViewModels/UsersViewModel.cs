using System.Collections.Generic;
using System.Collections.ObjectModel;
using OOP_Lab_3.Base;
using OOP_Lab_3.Events;
using OOP_Lab_3.Models;
using OOP_Lab_3.Storage.StorageManagers;

namespace OOP_Lab_3.ViewModels
{
    public class UsersViewModel : BindableBase
    {
        public ObservableCollection<User> Users { get; set; }
        public MyICommand<string> NavCommand { get; private set; }

        public UsersViewModel()
        {
            LoadUsers();
            NavCommand = new MyICommand<string>(OnNavigation);
        }

        private void OnNavigation(string destination)
        {
            NavigationEvent.GoTo(destination);
        }

        private void LoadUsers()
        {
            Users = new ObservableCollection<User>(
                UserStorageManager
                    .Instance
                    .GetItemsList() as List<User>
                );
        }
    }
}