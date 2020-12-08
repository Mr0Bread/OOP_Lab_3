using System;

namespace OOP_Lab_3.Events
{
    public static class NavigationEvent
    {
        public static void GoTo(string destination)
        {
            HandleNavigation?.Invoke(destination);
        }
        
        public static Action<string> HandleNavigation;
    }
}