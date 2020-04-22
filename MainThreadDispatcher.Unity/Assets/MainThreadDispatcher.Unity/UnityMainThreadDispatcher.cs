using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace MainThreadDispatcher.Unity
{
    public sealed class UnityMainThreadDispatcher : MonoBehaviour, IMainThreadDispatcher
    {
        private readonly ConcurrentQueue<Task> _taskQueue = new ConcurrentQueue<Task>();
        private int _mainThreadId = -1;

        private static int CurrentThreadId => Thread.CurrentThread.ManagedThreadId;

        public void Invoke(Action action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            if (CurrentThreadId == _mainThreadId)
            {
                action();

                return;
            }

            _taskQueue.Enqueue(new Task(action));
        }

        public Task InvokeAsync(Action action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            if (CurrentThreadId == _mainThreadId)
            {
                action();

                return Task.CompletedTask;
            }

            var task = new Task(action);

            _taskQueue.Enqueue(task);

            return task;
        }

        public Task<T> InvokeAsync<T>(Func<T> func)
        {
            if (func is null) throw new ArgumentNullException(nameof(func));

            if (CurrentThreadId == _mainThreadId) return Task.FromResult(func());

            var task = new Task<T>(func);

            _taskQueue.Enqueue(task);

            return task;
        }

        private void Awake() => _mainThreadId = CurrentThreadId;

        private void Update()
        {
            while (_taskQueue.TryDequeue(out var task))
            {
                try
                {
                    task.RunSynchronously();
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }
}
