using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyProgram myProgram = null;
            try
            {
                myProgram = new MyProgram();
                Console.WriteLine("Программа работает");
                Console.ReadKey();
                myProgram.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            myProgram?.Dispose();
        }

    }
}
