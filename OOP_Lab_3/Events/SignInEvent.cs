using System;

namespace OOP_Lab_3.Events
{
    public static class SignInEvent
    {
        public static void signIn(bool isSignedIn)
        {
            HandleSignIn?.Invoke(isSignedIn);
        }
        
        public static Action<bool> HandleSignIn;
    }
}