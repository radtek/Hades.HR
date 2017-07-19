using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SFYX.Framework.Starter
{
    internal static class TaskExt
    {
        /// <summary>
        /// 异步执行任务
        /// </summary>
        /// <param name="taskSource">任务源</param>
        /// <param name="timeout">超时，默认3秒</param>
        /// <returns></returns>
        public static async Task TimeOut(this Task taskSource, int timeout = 3)
        {
            Task timeoutTask = TaskEx.Delay(timeout * 1000);
            var result = await TaskEx.WhenAny(timeoutTask, taskSource);

            if (result == timeoutTask)
            {
                throw new TimeoutException("任务执行超时");
            }
        }


        /// <summary>
        /// 异步执行任务
        /// </summary>
        /// <param name="taskSource">任务源</param>
        /// <param name="timeout">超时，默认3秒</param>
        /// <returns></returns>
        public static async Task<T> TimeOut<T>(this Task<T> taskSource, int timeout = 3)
        {
            Task timeoutTask = TaskEx.Delay(timeout * 1000);
            var result = await TaskEx.WhenAny(timeoutTask, taskSource);

            if (result == timeoutTask)
            {
                throw new TimeoutException("任务执行超时");
            }
            return taskSource.Result;
        }

        public static async Task CallerAsync(Action action, int timeout = 15)
        {
            var tcs = new TaskCompletionSource<int>();
            Task task = Task.Factory.StartNew(() => {
                try
                {
                    action();
                    tcs.TrySetResult(1);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                    tcs.TrySetCanceled();
                    tcs.TrySetResult(0);
                }
            });

            Task timeoutTask = TaskEx.Delay(timeout * 1000);
            var result = await TaskEx.WhenAny(timeoutTask, task);

            if (result == timeoutTask)
            {
                tcs.TrySetCanceled();
                throw new TimeoutException("任务执行超时");
            }
        }


        public static async Task<T> CallerAsync<T>(Func<T> func, int timeout = 15)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

            var task = Task.Factory.StartNew(() =>
            {
                try
                {
                    tcs.TrySetResult(func());
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                    tcs.TrySetCanceled();
                }
            });

            Task timeoutTask = TaskEx.Delay(timeout * 1000);
            var result = await TaskEx.WhenAny(timeoutTask, task);
            if (result == timeoutTask)
            {
                tcs.TrySetCanceled();
                throw new TimeoutException("任务执行超时");
            }
            return tcs.Task.Result;
        }
    }
}
