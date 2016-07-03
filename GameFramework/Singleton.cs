namespace GameFramework
{
    public static class Singleton<T> where T : new()
    {
        private static T instance;

        public static T Instace
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}
