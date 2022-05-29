using System;
using System.Collections.Generic;
using System.Threading;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitHandle[] waitHandles = new WaitHandle[20];
            Resource resource = new Resource();
            List<Thread> threads = new List<Thread>();
            Logger logger = new Logger();

            for (int i = 0; i < 20; i++)
            {
                waitHandles[i] = new EventWaitHandle(false, EventResetMode.ManualReset);
                threads.Add(new Thread(new ParameterizedThreadStart(resource.GetAccess)));
                threads[i].Start(new object[] { logger, waitHandles[i] });
            }

            WaitHandle.WaitAll(waitHandles);
            Console.ReadKey();
        }
    }

    internal class Resource
    {
        readonly Semaphore _semaphore = new Semaphore(5, 10);
        public void GetAccess(object logger)
        {
            _semaphore.WaitOne();
            ((logger as object[])[0] as Logger).Log($"Доступ получен потоком {Thread.CurrentThread.ManagedThreadId} - {DateTime.Now.ToString()}: ms - {DateTime.Now.Millisecond}");
            ((logger as object[])[1] as EventWaitHandle).Set();
            _semaphore.Release();
        }
    }
}
