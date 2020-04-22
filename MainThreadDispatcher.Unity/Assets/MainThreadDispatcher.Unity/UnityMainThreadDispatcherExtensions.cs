using UnityEngine;

namespace MainThreadDispatcher.Unity
{
    public static class UnityMainThreadDispatcherExtensions
    {
        private static UnityMainThreadDispatcher _instance;

        public static UnityMainThreadDispatcher Instance
        {
            get
            {
                if (_instance is null) _instance = Object.FindObjectOfType<UnityMainThreadDispatcher>();

                return _instance;
            }
        }
    }
}