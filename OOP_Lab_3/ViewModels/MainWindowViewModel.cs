using OOP_Lab_3.Base;
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
        }

        private void HandleSignIn(bool isSignedInd)
        {
            if (isSignedInd)
            {
                CurrentViewModel = _mainMenuViewModel;
            }
        }
    }
}