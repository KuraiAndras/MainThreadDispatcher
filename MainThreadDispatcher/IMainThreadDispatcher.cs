using System;
using System.Threading.Tasks;

namespace MainThreadDispatcher
{
    public interface IMainThreadDispatcher
    {
        /// <summary>
        /// Invoke action on main thread. Does not guarantee completion upon return
        /// </summary>
        /// <param name="action">Action to run</param>
        void Invoke(Action action);

        /// <summary>
        /// Invoke action on main thread
        /// </summary>
        /// <param name="action">Action to run</param>
        /// <returns>Task completes when action is completed</returns>
        Task InvokeAsync(Action action);

        /// <summary>
        /// Invoke action on main thread
        /// </summary>
        /// <param name="func">Action to run</param>
        /// <returns>Task completes when action is completed</returns>
        Task<T> InvokeAsync<T>(Func<T> func);
    }
}