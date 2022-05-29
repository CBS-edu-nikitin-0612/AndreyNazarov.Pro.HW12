using System;
using System.IO;
using System.Threading;

namespace Task5
{
    internal class Logger 
    {
        private readonly FileInfo _file = null;

        public Logger()
        {
            _file = new FileInfo("log.txt");
        }

        public void Log(object message)
        {
            StreamWriter writer = null;
            lock (this)
            {
                try
                {
                    Thread.Sleep(1000);
                    writer = new StreamWriter(_file.Open(FileMode.Append, FileAccess.Write));
                    writer.WriteLine(message.ToString());
                    Console.WriteLine(message.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    writer?.Close();//TODO Без этой паузы иногда падают ошибки доступа к файлу, мне кажется потому что файл не усспевает закрыватьсся. Как иправить без этой паузы?
                    Thread.Sleep(300);
                }
            }
        }
    }
}