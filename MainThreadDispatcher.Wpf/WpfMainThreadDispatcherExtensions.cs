namespace MainThreadDispatcher.Wpf
{
    public static class WpfMainThreadDispatcherExtensions
    {
        private static bool _initialized;
        private static IMainThreadDispatcher _dispatcher;

        public static IMainThreadDispatcher Instance
        {
            get
            {
                if (_initialized) return _dispatcher;

                _initialized = true;
                _dispatcher = new WpfMainThreadDispatcher();

                return _dispatcher;
            }
        }
    }
}