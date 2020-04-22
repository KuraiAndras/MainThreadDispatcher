# MainThreadDispatcher

[![Nuget](https://img.shields.io/nuget/v/MainThreadDispatcher)](https://www.nuget.org/packages/MainThreadDispatcher/)

A simple interface to hide platform/framework specific implementations of dispatching to a main thread.

```c#
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
```
## Implementations
| Name     | Link                                                                                                                                                                                           |
|----------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Unity 3D | [![openupm](https://img.shields.io/npm/v/com.mainthreaddispatcher.unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.mainthreaddispatcher.unity/) |
| WPF | [![Nuget](https://img.shields.io/nuget/v/MainThreadDispatcher.Wpf)](https://www.nuget.org/packages/MainThreadDispatcher.Wpf/)