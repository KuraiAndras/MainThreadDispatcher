using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MainThreadDispatcher.Xamarin.Forms
{
    public sealed class XamarinFormsMainThreadDispatcher
    {
        public void Invoke(Action action) => MainThread.BeginInvokeOnMainThread(action);

        public async Task InvokeAsync(Action action) => await MainThread.InvokeOnMainThreadAsync(action);

        public async Task<T> InvokeAsync<T>(Func<T> func) => await MainThread.InvokeOnMainThreadAsync(func);
    }
}
