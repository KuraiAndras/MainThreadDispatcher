using System;
using System.Threading.Tasks;

namespace MainThreadDispatcher
{
    public sealed class FakeDispatcher : IMainThreadDispatcher
    {
        public void Invoke(Action action) => action();

        public Task InvokeAsync(Action action)
        {
            action();

            return Task.CompletedTask;
        }

        public Task<T> InvokeAsync<T>(Func<T> func) => Task.FromResult(func());
    }
}
