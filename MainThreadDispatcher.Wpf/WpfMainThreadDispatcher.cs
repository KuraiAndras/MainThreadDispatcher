using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MainThreadDispatcher.Wpf
{
    public sealed class WpfMainThreadDispatcher : IMainThreadDispatcher
    {
        private readonly int _mainThreadId;
        private readonly Dispatcher _dispatcher;

        public WpfMainThreadDispatcher()
        {
            _mainThreadId = Thread.CurrentThread.ManagedThreadId;
            _dispatcher = Application.Current.Dispatcher;
        }

        public void Invoke(Action action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            if (Thread.CurrentThread.ManagedThreadId == _mainThreadId)
            {
                action();

                return;
            }

            _dispatcher.Invoke(action);
        }

        public async Task InvokeAsync(Action action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            if (Thread.CurrentThread.ManagedThreadId == _mainThreadId)
            {
                action();

                return;
            }

            await _dispatcher.InvokeAsync(action);
        }

        public async Task<T> InvokeAsync<T>(Func<T> func)
        {
            if (func is null) throw new ArgumentNullException(nameof(func));

            if (Thread.CurrentThread.ManagedThreadId == _mainThreadId)
            {
                return func();
            }

            return await _dispatcher.InvokeAsync(func);
        }
    }
}
