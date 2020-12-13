using OOP_Lab_3.Base;

namespace OOP_Lab_3.Navigation
{
    public class View
    {
        public readonly string ViewName;
        public readonly string ViewModelName;

        public View(string viewName, string viewModelName)
        {
            ViewName = viewName;
            ViewModelName = viewModelName;
        }
    }
}