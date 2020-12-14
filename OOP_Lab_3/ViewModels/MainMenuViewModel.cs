using System;
using OOP_Lab_3.Base;
using OOP_Lab_3.Events;

namespace OOP_Lab_3.ViewModels
{
    public class MainMenuViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<Boolean> SignOutCommand { get; private set; }

        public MainMenuViewModel()
        {
            NavCommand = new MyICommand<string>(OnNavigation);
            SignOutCommand = new MyICommand<bool>(OnSignOut);
        }

        private void OnNavigation(string destination)
        {
           NavigationEvent.GoTo(destination);
        }
        
        private void OnSignOut (bool value)
        {
            SignInEvent.SignIn(false);
        }
    }
}