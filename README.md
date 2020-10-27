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
| Xamarin.Forms | [![Nuget](https://img.shields.io/nuget/v/MainThreadDispatcher.Xamarin.Forms)](https://www.nuget.org/packages/MainThreadDispatcher.Xamarin.Forms/)

# MainThreadDispatcher.Unity

Since version 1.1.1 you need to provide the following dlls yourself:
- MainThreadDispatcher


[![openupm](https://img.shields.io/npm/v/com.mainthreaddispatcher.unity?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.mainthreaddispatcher.unity/)

An implementation of the [IMainThreadDispatcher](https://github.com/KuraiAndras/MainThreadDispatcher) interface in Unity 3D

## Usage

Add a GameObject to you scene and add the UnityMainThreadDispatcher script to it. Make sure that this GameObject is in your scene.

```c#
//Getting an instance with static method
IMainThreadDispatcher dispatcher = UnityMainThreadDispatcherExtensions.Instance;

dispatcher.Invoke(() => Debug.Log("Hello 1"));
await dispatcher.InvokeAsync(() => Debug.Log("Hello 2"))

Button button = await dispatcher.InvokeAsync(() => GameObject.FindObjectOfType<Button>()))    
```

Calling the dispatcher is thread safe

## Gotchas

If you call UnityMainThreadDispatcherExtensions.Instance before the the GameObject containing it is instantiated you will get an exception.

If you call UnityMainThreadDispatcherExtensions.Instance for the first time from a thread other than the main unity thread, you will get an exception.

If there are multiple instances in you scene, then when calling UnityMainThreadDispatcherExtensions.Instance it will cache the first it finds. Preferably you only want one instance of it in your application, having multiple does not provide any performance benefit

# MainThreadDispatcher.WPF

If you create the WpfMainThreadDispatcher instance on a thread other than the main thread it will not work. It is recommended to create a shared instance. You can achieve this with Dependency Injection or with eagerly creating an Instance with the provided extension class.

# MainThreadDispatcher.Xamarin.Forms

This package wraps around Xamarin.Essentials.MainThread, thus you need to [set up Xamarin.Essentials](https://docs.microsoft.com/en-us/xamarin/essentials/get-started?tabs=windows%2Candroid).