using System;

namespace GameFramework
{
    public class EventEngine
    {
        public static event Action OnClear = () => { };

        public static void Clear()
        {
            OnClear();
        }

        public static void Fire<T>(T t)
        {
            EventBus<T>.FireEvent(t);
        }

        public static void SignIn<T>(Action<T> t)
        {
            EventBus<T>.SignIn(t);
        }

        public static void SignIn<T>(Action<T> method, int priority)
        {
            EventBus<T>.SignIn(method, priority);
        }

        public static void SignOut<T>(Action<T> t)
        {
            EventBus<T>.SignOut(t);
        }
    }
}
