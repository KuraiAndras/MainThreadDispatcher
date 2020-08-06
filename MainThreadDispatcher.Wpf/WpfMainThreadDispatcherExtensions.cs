namespace MainThreadDispatcher.Wpf
{
    public static class WpfMainThreadDispatcherExtensions
    {
        private static IMainThreadDispatcher? _dispatcher;

        public static IMainThreadDispatcher Instance => _dispatcher ??= new WpfMainThreadDispatcher();
    }
}
