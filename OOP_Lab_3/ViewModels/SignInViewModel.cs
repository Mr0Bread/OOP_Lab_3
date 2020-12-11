using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using OOP_Lab_3.Base;
using OOP_Lab_3.Events;
using OOP_Lab_3.Models;
using OOP_Lab_3.Storage.StorageManagers;

namespace OOP_Lab_3.ViewModels
{
    public class SignInViewModel : BindableBase
    {
        public MyICommand<object> SignInCommand { get; private set; }

        public SignInViewModel()
        {
            SignInCommand = new MyICommand<object>(OnSignIn);
        }

        private void OnSignIn(object parameter)
        {
            var values = (object[]) parameter;
            var login = ((TextBox) values[0]).Text;
            var password = ((PasswordBox) values[1]).Password;

            var userList = UserStorageManager.Instance.GetItemsList();

            if (login.Length == 0 || password.Length == 0)
            {
                NotificationEvent.Notify("Fields should not be empty!");
                return;
            }

            if (userList.Any(user => user.Login == login && user.Password == password))
            {
                SignInEvent.SignIn(true);
                return;
            }
            
            NotificationEvent.Notify("Incorrect Credentials!");
            SignInEvent.SignIn(false);
        }
    }
}