using System;
using System.Linq;
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
            var view = Navigation.Navigation.Pages
                .FirstOrDefault(x => x.ViewName == destination);
            
            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from t in assembly.GetTypes()
                where t.Name == view.ViewModelName
                select t).FirstOrDefault();
            
            CurrentViewModel = (BindableBase) Activator.CreateInstance(type);
        }
    }
}