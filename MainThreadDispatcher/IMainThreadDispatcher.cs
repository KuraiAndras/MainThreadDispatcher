using System;
using System.Threading.Tasks;

namespace MainThreadDispatcher
{
    public interface IMainThreadDispatcher
    {
        void Invoke(Action action);
        Task InvokeAsync(Action action);
        Task<T> InvokeAsync<T>(Func<T> func);
    }
}