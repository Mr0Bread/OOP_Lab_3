using System;

namespace OOP_Lab_3.Events
{
    public static class NotificationEvent
    {
        public static void Notify(string message)
        {
            HandleNotification?.Invoke(message);
        }
        
        public static Action<string> HandleNotification;
    }
}