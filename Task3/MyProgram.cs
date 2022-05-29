using System;
using System.Threading;

namespace Task3
{
    internal class MyProgram : IDisposable
    {
        private readonly Mutex _mutex;
        public MyProgram()
        {
            _mutex = new Mutex(true, GetType().AssemblyQualifiedName);
            try
            {
                _mutex.ReleaseMutex();
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("Один экземпляр программы уже был запущен");
                _mutex?.Dispose();
                throw;
            }
        }

        public void Dispose()
        {
            _mutex.Dispose();
        }
    }
}
